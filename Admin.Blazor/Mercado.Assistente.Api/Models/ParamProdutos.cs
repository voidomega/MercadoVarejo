using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.MercadoAssistente.Api.Models
{
    public class ParamProdutos
    {
        public long? IdProduto { get; set; }
        public int? IdMarca { get; set; }
        public int? IdFamilia { get; set; }
        public string? NmProduto { get; set; }

        public decimal? VlPreco { get; set; }
        


    }
}
