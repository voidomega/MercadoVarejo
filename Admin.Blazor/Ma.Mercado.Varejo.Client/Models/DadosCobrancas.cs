using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class DadosCobrancas
    {
        [Display(Name="ID",Description="ID")]
        [Key]
        public long IdDadosCobranca { get; set; }
        
        [Display(Name="ID Pedido",Description="Id do Pedido")]
        public long? IdPedido { get; set; }
        
        [Display(Name="Tipo de Cobrança",Description="Id do Tipo de Cobrança")]
        public int? IdTipoCobranca { get; set; }
        
        [Display(Name="Cartão",Description="Número do Cartão")]
        [StringLength(512)]
        public string NrCartao { get; set; }
        
        [Display(Name="Nome no Cartão",Description="Nome no Cartão")]
        [StringLength(512)]
        public string NmCartao { get; set; }
        
        [Display(Name="Autorização",Description="Autorização")]
        [StringLength(100)]
        public string DsAutorizacao { get; set; }
        
        [Display(Name="CPF/CNPJ",Description="CPF/CNPJ")]
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        
        [Display(Name="Status",Description="Status do Cartão")]
        [StringLength(6)]
        public string StCartao { get; set; }
        
        
        [Display(Name="Valor a Pagar",Description="Valor a Pagar")]
        public decimal VlPago { get; set; }
        

        [JsonIgnore]
        [InverseProperty("DadosCobrancas")]
        [ForeignKey("IdPedido")]
        public virtual Pedidos IdPedidoNavigation { get; set; }

        [ForeignKey("IdTipoCobranca")]
        [InverseProperty("DadosCobrancas")]
        [JsonIgnore]
        public virtual TipoCobranca IdTipoCobrancaNavigation { get; set; }

    }
}
