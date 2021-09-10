using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoAssistente.Local.Domain
{
    /// <summary>
    /// Modelo Usuário.
    /// </summary>
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string IdFilial { get; set; }
        public string NmUsuario { get; set; }
        public string NmApelido { get; set; }
        public int IdGrupoEmpresa { get; set; }
        public string DsEmail { get; set; }
        public string DsHashSenha { get; set; } 
        public int TipoUsuario { get; set; }
    }
}
