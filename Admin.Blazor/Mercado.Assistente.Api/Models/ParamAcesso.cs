using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoAssistente.Api.Models
{
    public class ParamAcesso
    {
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }
        public char TpAcessoUsuario { get; set; }
    }

    public class UsrLogado
    {
        public int IdUsrLogado { get; set; }
        public string NmUsrLogado { get; set; }
        public string DsNmUsuario { get; set; }
        public string DsEmail { get; set; }        
        public char TpAcessoUsuario { get; set; }
        
        
    }
}
