using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class Familias : BaseEntity
    {
        public Familias()
        {
            Produtos = new HashSet<Produtos>();
            PromocaoProdutos = new HashSet<PromocaoProdutos>();
        }

        [Key]
        public int IdFamilia { get; set; }
        [Required]
        [StringLength(256)]
        public string DsFamilia { get; set; }
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categorias.Familias))]
        public virtual Categorias IdCategoriaNavigation { get; set; }
        [InverseProperty("IdFamiliaNavigation")]
        public virtual ICollection<Produtos> Produtos { get; set; }
        [InverseProperty("IdFamiliaNavigation")]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }
    }
}
