using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class ItemPedidos
    {
        [Key]
        public long IdItemPedido { get; set; }
        
        [Display(Name="Pedido",Description="Id do Pedido")]
        public long IdPedido { get; set; }
        
        [Display(Name="Produto",Description="Id do Produto")]
        public long IdProduto { get; set; }
        
        
        [Display(Name="Quantidade",Description="Quantidade")]
        public decimal QtPedida { get; set; }
        
        [Display(Name="Unidade",Description="Unidade")]
        [StringLength(25)]
        public string DsUnidade { get; set; }
        
        
        [Display(Name="Qtd. Entregue",Description="Quantidade Entregue")]
        public decimal QtEntregue { get; set; }
        
        
        [Display(Name="Desconto",Description="Valor do Desconto")]
        public decimal? VlDesconto { get; set; }
        
        
        [Display(Name="Valor",Description="Valor unitário")]
        public decimal VlUnitario { get; set; }
        
        
        [Display(Name="Total",Description="Valor Total")]
        public decimal VlTotalItem { get; set; }
        
        
        [Display(Name="Frete",Description="Valor do Frete")]
        public decimal? VlFrete { get; set; }
        

        [JsonIgnore]
        [InverseProperty("ItemPedidos")]
        [ForeignKey("IdPedido")]
        public virtual Pedidos IdPedidoNavigation { get; set; }

        [ForeignKey("IdProduto")]
        [InverseProperty("ItemPedidos")]
        [JsonIgnore]
        public virtual Produtos IdProdutoNavigation { get; set; }

    }
}
