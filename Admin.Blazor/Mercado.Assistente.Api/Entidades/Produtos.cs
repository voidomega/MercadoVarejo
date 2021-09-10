using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class Produtos : BaseEntity
    {
        public Produtos()
        {
            ImagensProduto = new HashSet<ImagensProduto>();
            ItemPedidos = new HashSet<ItemPedidos>();
            PromocaoProdutos = new HashSet<PromocaoProdutos>();
        }

        [Key]
        public long IdProduto { get; set; }
        [StringLength(512)]
        public string NmProduto { get; set; }
        public int IdMarca { get; set; }
        [StringLength(80)]
        public string DsCurtaProduto { get; set; }
        [StringLength(4000)]
        public string DsObsProduto { get; set; }
        [StringLength(25)]
        public string DsUnidade { get; set; }
        [Column(TypeName = "money")]
        public decimal? VlDesconto { get; set; }
        [Column(TypeName = "money")]
        public decimal? VlPreco { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DtIniValidadeDesconto { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DtFimValidadeDesconto { get; set; }
        [Column(TypeName = "numeric(15,5)")]
        public decimal? VlQtdUnidade { get; set; }
        [StringLength(25)]
        public string TpDesconto { get; set; }
        public int? IdFamilia { get; set; }

        [ForeignKey(nameof(IdFamilia))]
        [InverseProperty(nameof(Familias.Produtos))]
        public virtual Familias IdFamiliaNavigation { get; set; }
        [ForeignKey(nameof(IdMarca))]
        [InverseProperty(nameof(Marcas.Produtos))]
        public virtual Marcas IdMarcaNavigation { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<ImagensProduto> ImagensProduto { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<ItemPedidos> ItemPedidos { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }
    }
}
