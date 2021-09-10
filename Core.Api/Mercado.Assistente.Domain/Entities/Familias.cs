using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
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
        
        [Display(Name="Familia",Description="Familia")]
        [StringLength(256)]
        [Required]
        public string DsFamilia { get; set; }
        
        [Display(Name="Categoria",Description="Categoria")]
        public int IdCategoria { get; set; }
        

        [JsonIgnore]
        [ForeignKey("IdCategoria")]
        [InverseProperty("Familias")]
        public virtual Categorias IdCategoriaNavigation { get; set; }

        [InverseProperty("IdFamiliaNavigation")]
        [JsonIgnore]
        public virtual ICollection<Produtos> Produtos { get; set; }

        [InverseProperty("IdFamiliaNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }

    }
}
