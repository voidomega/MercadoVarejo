using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Ma.MercadoAssistente.Api.Entidades
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

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Clientes.Pedidos))]
        public virtual Clientes IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdSituacaoPedido))]
        [InverseProperty(nameof(SituacaoPedidos.Pedidos))]
        public virtual SituacaoPedidos IdSituacaoPedidoNavigation { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<DadosCobrancas> DadosCobrancas { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<HistoricoPedidos> HistoricoPedidos { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<ItemPedidos> ItemPedidos { get; set; }
    }
}
