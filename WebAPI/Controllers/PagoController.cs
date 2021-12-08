﻿using BusinessLayer;
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
    public class PagoController : ControllerBase
    {
        private readonly IBL_Pago ibl_Pago;
        private readonly IBL_Factura ibl_Factura;
        private readonly PayPalSetting Configuration;

        public PagoController(IBL_Pago _pago, IOptions<PayPalSetting> Configuration, IBL_Factura _factura)
        {
            ibl_Pago = _pago;
            ibl_Factura = _factura;
            this.Configuration = Configuration.Value;
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
        public ActionResult Post([FromBody] AgregarPagoDto x)
        {
            return Ok(ibl_Pago.AddPago(x));
        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
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

        [HttpGet("Pagar/{IdFactura}")]
        public void Pago(Guid IdFactura)
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
                item_list = itemList
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

            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    Response.Redirect(link.href);
                }
            }
        }


        [HttpGet("success")]
        public dynamic Success(string paymentId, string PayerId, string token)
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

            return Ok(executePayment);
        }
    }
}