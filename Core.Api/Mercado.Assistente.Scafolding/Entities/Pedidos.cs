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
        
        public int IdCliente { get; set; }
        
        [Column(TypeName = "money")]
        public decimal VlTotal { get; set; }
        
        [Required]
        [StringLength(3)]
        public string TpFracionado { get; set; }
        
        public int QtdItens { get; set; }
        
        [Column(TypeName = "money")]
        public decimal? VlTotalFrete { get; set; }
        
        public int IdSituacaoPedido { get; set; }
        
        public DateTime DtPedido { get; set; }
        

        [ForeignKey("IdCliente")]
        [InverseProperty("Pedidos")]
        [JsonIgnore]
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
