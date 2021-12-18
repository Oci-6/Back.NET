using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PayPal.Api;
using Shared.Dominio.Pago;
using Shared.Dominio.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagoController : ControllerBase
    {
        private readonly IBL_Pago ibl_Pago;
        private readonly IBL_Factura ibl_Factura;
        private readonly PayPalSetting Configuration;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IBL_Emails emails;

        public PagoController(IBL_Pago _pago, IOptions<PayPalSetting> Configuration, IBL_Factura _factura, IHttpContextAccessor _contextAccessor, IBL_Emails emails)
        {
            ibl_Pago = _pago;
            ibl_Factura = _factura;
            this.Configuration = Configuration.Value;
            this.contextAccessor = _contextAccessor;
            this.emails = emails;

        }

        // GET: api/<PagoController>
        [HttpGet("Factura/{idFactura}")]
        public ActionResult<IEnumerable<PagoDto>> GetPagoFactura(Guid IdFactura)
        {
            return Ok(ibl_Pago.GetPagoFactura(IdFactura));
        }

        // GET api/<PagoController>/5
        [HttpGet("{id}")]
        public ActionResult<PagoDto> Get(Guid id)
        {
            var pago = ibl_Pago.GetPago(id);

            if (pago == null)
            {
                return NotFound();
            }
            return Ok(pago);
        }

        // POST api/<PagoController>
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Post([FromBody] AgregarPagoDto x)
        {
            return Ok(ibl_Pago.AddPago(x));
        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Put(Guid id, [FromBody] PagoDto x)
        {
            var pago = ibl_Pago.GetPago(id);
            if (pago == null)
            {
                return NotFound();
            }
            ibl_Pago.PutPago(x, id);
            return NoContent();
        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult Delete(Guid id)
        {
            var pago = ibl_Pago.GetPago(id);
            if (pago == null)
            {
                return NotFound();
            }
            ibl_Pago.DeletePago(id);
            return NoContent();
        }

        [HttpGet("Paypal/Pagar/{IdFactura}")]
        [AllowAnonymous]

        public ActionResult Pago(Guid IdFactura)
        {
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox");
            config.Add("clientId", Configuration.ClientID);
            config.Add("clientSecret", Configuration.Secret);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var factura = ibl_Factura.GetFactura(IdFactura);
            var payer = new Payer() { payment_method = "paypal" };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = Configuration.CancelUrl,
                return_url = Configuration.ReturnUrl
            };

            var itemList = new ItemList()
            {
                items = new List<Item>()
                {
                    new Item()
                    {
                        name = factura.Descripcion,
                        currency = "USD",
                        price = factura.Importe.ToString(),
                        quantity = "1",
                        sku = "sku"
                    }
                }
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = factura.Importe.ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = factura.Importe.ToString(), //Total = shipping+tax+subtotal
                details = details
            };

            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Pago de mensualidad",
                amount = amount,
                item_list = itemList,
                custom = factura.Id.ToString()
            });

            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                redirect_urls = redirUrls,
                transactions = transactionList
            };

            var createPayment = payment.Create(apiContext);

            var links = createPayment.links.GetEnumerator();
            var res = "";
            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    res = link.href;
                }
            }
            return Ok(new { message = res });

        }


        [HttpGet("Paypal/success")]
        [AllowAnonymous]
        public async Task SuccessAsync(string paymentId, string PayerId, string token)
        {
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox");
            config.Add("clientId", Configuration.ClientID);
            config.Add("clientSecret", Configuration.Secret);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var paymentExecution = new PaymentExecution() { payer_id = PayerId };
            var payment = new Payment() { id = paymentId };

            var executePayment = payment.Execute(apiContext, paymentExecution);
            if(executePayment.state == "approved")
            {
                var id = executePayment.transactions.Where(t => t.custom != null).FirstOrDefault().custom;
                var res = ibl_Pago.AddPago(new AgregarPagoDto() { FacturaId = Guid.Parse(id) });
                await emails.EnviarPagoAsync(ibl_Factura.GetFactura(Guid.Parse(id)));
                Response.Redirect(Configuration.FrontUrl + "/success?id=" + res.Id.ToString());
            }
            else
            {
                Response.Redirect(Configuration.FrontUrl + "/failed");
            }
        }

        [HttpGet("Paypal/cancel")]
        [AllowAnonymous]
        public void Cancel(string paymentId, string PayerId, string token)
        {
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox");
            config.Add("clientId", Configuration.ClientID);
            config.Add("clientSecret", Configuration.Secret);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var paymentExecution = new PaymentExecution() { payer_id = PayerId };
            var payment = new Payment() { id = paymentId };

            Response.Redirect(Configuration.FrontUrl + "/failed");
        }
    }
}
