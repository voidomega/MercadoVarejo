using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ma.Mercado.Varejo.Client.Classes
{
    public class ConvJsonContent : StringContent
    {
        public ConvJsonContent(object obj) :
        base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        {
            
        }
    }
}