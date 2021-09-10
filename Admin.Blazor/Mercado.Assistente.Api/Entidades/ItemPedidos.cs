using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class ItemPedidos : BaseEntity
    {
        [Key]
        public long IdItemPedido { get; set; }
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        [Column(TypeName = "numeric(15,5)")]
        public decimal QtPedida { get; set; }
        [StringLength(25)]
        public string DsUnidade { get; set; }
        [Column(TypeName = "numeric(15,5)")]
        public decimal QtEntregue { get; set; }
        [Column(TypeName = "money")]
        public decimal? VlDesconto { get; set; }
        [Column(TypeName = "money")]
        public decimal VlUnitario { get; set; }
        [Column(TypeName = "money")]
        public decimal VlTotalItem { get; set; }
        [Column(TypeName = "money")]
        public decimal? VlFrete { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(Pedidos.ItemPedidos))]
        public virtual Pedidos IdPedidoNavigation { get; set; }
        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.ItemPedidos))]
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
