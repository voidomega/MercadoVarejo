using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class PromocaoProdutos : BaseEntity
    {
        [Key]
        public int IdPromocaoProdutos { get; set; }
        public long? IdProduto { get; set; }
        [Required]
        [StringLength(3)]
        public string TpDesconto { get; set; }
        [Column(TypeName = "numeric(18,0)")]
        public decimal PctDesconto { get; set; }
        [Column(TypeName = "numeric(18,0)")]
        public decimal VlDesconto { get; set; }
        public DateTime DtInicioPromocao { get; set; }
        public DateTime? DtFimPromocao { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdFamilia { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categorias.PromocaoProdutos))]
        public virtual Categorias IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdFamilia))]
        [InverseProperty(nameof(Familias.PromocaoProdutos))]
        public virtual Familias IdFamiliaNavigation { get; set; }
        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.PromocaoProdutos))]
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
