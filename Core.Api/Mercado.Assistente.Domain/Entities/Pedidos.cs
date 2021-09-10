using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class Pedidos : BaseEntity
    {
        public Pedidos()
        {
            DadosCobrancas = new HashSet<DadosCobrancas>();
            HistoricoPedidos = new HashSet<HistoricoPedidos>();
            ItemPedidos = new HashSet<ItemPedidos>();
        }

        [Key]
        public long IdPedido { get; set; }
        
        [Display(Name="Cliente",Description="Id do Cliente")]
        public int IdCliente { get; set; }
        
        
        [Display(Name="Total",Description="Valor Total")]
        public decimal VlTotal { get; set; }
        
        [Display(Name="Fracionamento",Description="Tipo Fracionamento")]
        [StringLength(3)]
        [Required]
        public string TpFracionado { get; set; }
        
        [Display(Name="Nº itens",Description="Quantidade de Itens")]
        public int QtdItens { get; set; }
        
        
        [Display(Name="Valor",Description="Valor total")]
        public decimal? VlTotalFrete { get; set; }
        
        [Display(Name="Situação",Description="Situação pedido")]
        public int IdSituacaoPedido { get; set; }
        
        [Display(Name="Data",Description="Data do pedido")]
        public DateTime DtPedido { get; set; }
        

        [JsonIgnore]
        [ForeignKey("IdCliente")]
        [InverseProperty("Pedidos")]
        public virtual Clientes IdClienteNavigation { get; set; }

        [ForeignKey("IdSituacaoPedido")]
        [InverseProperty("Pedidos")]
        [JsonIgnore]
        public virtual SituacaoPedidos IdSituacaoPedidoNavigation { get; set; }

        [InverseProperty("IdPedidoNavigation")]
        [JsonIgnore]
        public virtual ICollection<DadosCobrancas> DadosCobrancas { get; set; }

        [InverseProperty("IdPedidoNavigation")]
        [JsonIgnore]
        public virtual ICollection<HistoricoPedidos> HistoricoPedidos { get; set; }

        [InverseProperty("IdPedidoNavigation")]
        [JsonIgnore]
        public virtual ICollection<ItemPedidos> ItemPedidos { get; set; }

    }
}
