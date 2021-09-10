using Ma.MercadoAssistente.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.MercadoAssistente.Api.Models
{
    public class ProdutoSel : Produtos
    {
        public string DsMarca { get; set; }
        public string DsFamilia { get; set; }

        public string TipoDesconto { get; set; }

    }
}
