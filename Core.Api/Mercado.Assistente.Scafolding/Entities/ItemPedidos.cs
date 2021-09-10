using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
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
        

        [ForeignKey("IdPedido")]
        [InverseProperty("ItemPedidos")]
        [JsonIgnore]
        public virtual Pedidos IdPedidoNavigation { get; set; }

        [ForeignKey("IdProduto")]
        [InverseProperty("ItemPedidos")]
        [JsonIgnore]
        public virtual Produtos IdProdutoNavigation { get; set; }

    }
}
