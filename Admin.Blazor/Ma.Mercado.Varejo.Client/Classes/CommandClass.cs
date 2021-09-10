using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.Mercado.Varejo.Client.Classes
{
    public class CommandClass
    {
        public string Tipo { get; set; }
        public string UrlPath { get; set; }
        public string ControllerName { get; set; }

        public string Method { get; set; }
        public string DataParam { get; set; }
    }
}
