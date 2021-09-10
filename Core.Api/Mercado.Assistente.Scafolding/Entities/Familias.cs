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
        
        [Required]
        [StringLength(256)]
        public string DsFamilia { get; set; }
        
        public int IdCategoria { get; set; }
        

        [ForeignKey("IdCategoria")]
        [InverseProperty("Familias")]
        [JsonIgnore]
        public virtual Categorias IdCategoriaNavigation { get; set; }

        [InverseProperty("IdFamiliaNavigation")]
        [JsonIgnore]
        public virtual ICollection<Produtos> Produtos { get; set; }

        [InverseProperty("IdFamiliaNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }

    }
}
