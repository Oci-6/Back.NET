using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shared.Dominio.Email;
using Shared.Dominio.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Emails : IBL_Emails
    {
        private readonly EmailSettings settings;
        private readonly UserManager<Usuario> userManager;


        public BL_Emails(UserManager<Usuario> _userManager,IOptions<EmailSettings> Configuration)
        {
            this.userManager = _userManager;
            this.settings = Configuration.Value;
        }

        public async Task<dynamic> EnviarEmailsAsync(string to, string emailName,string idTemplate, dynamic objectDynamic)
        {
            var client = new SendGridClient(settings.ApiKey);
            var fromEmail = new EmailAddress(settings.FromEmail, "Instituciones App");
            var toEmail = new EmailAddress(to, emailName);
            var msg = MailHelper.CreateSingleTemplateEmail(fromEmail, toEmail, idTemplate, objectDynamic);
            var response = await client.SendEmailAsync(msg);

            return response;
        }
        public async Task<dynamic> EnviarEmailsAsync(List<EmailAddress> destinatarios, string idTemplate, dynamic objectDynamic)
        {
            var client = new SendGridClient(settings.ApiKey);
            var fromEmail = new EmailAddress(settings.FromEmail, "Instituciones App");
            var msg = MailHelper.CreateSingleTemplateEmailToMultipleRecipients(fromEmail, destinatarios, idTemplate, objectDynamic);
            var response = await client.SendEmailAsync(msg);

            return response;
        }

        public async Task<dynamic> EnviarFacturasAsync(FacturaDto factura)
        {
            var admins = (await userManager.GetUsersInRoleAsync("Admin")).Where(element => element.TenantInstitucionId == factura.TenantInstitucionId).AsEnumerable();
            var destinatarios = new List<EmailAddress>();
            foreach (var item in admins)
            {
                destinatarios.Add(new EmailAddress(item.Email, item.Nombre));
            }

            return await EnviarEmailsAsync(destinatarios, "d-6b341e64210b4038b5047f52d0ae85e4",
            new
            {
                Importe = factura.Importe,
                Fecha_Vencimiento = factura.Fecha_Vencimiento,
                Descripcion = factura.Descripcion,
                Url = settings.Url
            });
          
        }

        public async Task<dynamic> EnviarPagoAsync(FacturaDto factura)
        {
            var admins = (await userManager.GetUsersInRoleAsync("Admin")).Where(element => element.TenantInstitucionId == factura.TenantInstitucionId).AsEnumerable();
            var destinatarios = new List<EmailAddress>();
            foreach (var item in admins)
            {
                destinatarios.Add(new EmailAddress(item.Email, item.Nombre));
            }

            return await EnviarEmailsAsync(destinatarios, "d-41d1a85c8e9c4178869ee73f6ad253e5",
            new
            {
                Importe = factura.Importe,
                FechaPago = factura.Pago.CreadoEn,
                Descripcion = factura.Descripcion,
                Url = settings.Url
            });

        }
    }
}
