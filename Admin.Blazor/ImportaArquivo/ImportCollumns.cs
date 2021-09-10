using System;
using System.Collections.Generic;
using System.Text;

namespace ImportaArquivo
{
    public class ImportCollumns
    {
        // Cód. Prod.;BP;Barra;;Cód. FV;Descrição PDV;;;QTD;ICMS;Estoque;Preço Custo;;Preço Venda;Margem Param;;Total Custo;;;Total Venda
        public string CodProd { get; set; }
        public string BP { get; set; }

        public string Barra { get; set; }

        
        public string CodFV { get; set; }
        public string DescricaoPDV { get; set; }


        public string Dados01 { get; set; }

        public string Dados02 { get; set; }
        public string Qtd { get; set; }
        public string Icms { get; set; }
        public string Estoque { get; set; }
        public string PrecoCusto { get; set; }

        public string Dados03 { get; set; }

        public string PrecoVenda { get; set; }

        public string MargemParam { get; set; }

        public string TotalCusto { get; set; }

        public string Dados04 { get; set; }

        public string Dados05 { get; set; }

        public string Dados06 { get; set; }
        public string Dados07 { get; set; }
        public string TotalVenda { get; set; }

        public string IdFamilia { get; set; }


    }
}
