using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dominio.PayPal
{
    public class PayPalSetting
    {
        public string ApiAppName { get; set; }
        public string Account { get; set; }
        public string ClientID { get; set; }
        public string Secret { get; set; }
        public string UrlApi { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}
