using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Models
{
    public static class DOMINIO
    {
        public const string YAHOO = "yahoo.com";
        public const string GMAIL = "gmail.com";
        public const string OUTLOOK = "outlook.com";
        public const string HOTMAIL = "hotmail.com";
        public static List<string> listaDomninios = new List<string>()
        {
            YAHOO,
            GMAIL,
            OUTLOOK,
            HOTMAIL
        };

    }

}
