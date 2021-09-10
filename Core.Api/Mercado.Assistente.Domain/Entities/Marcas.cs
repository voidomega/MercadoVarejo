using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class Marcas : BaseEntity
    {
        public Marcas()
        {
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        public int IdMarca { get; set; }
        
        [Display(Name="Marca",Description="Nome da Marca")]
        [StringLength(100)]
        [Required]
        public string DsMarca { get; set; }
        

        [InverseProperty("IdMarcaNavigation")]
        [JsonIgnore]
        public virtual ICollection<Produtos> Produtos { get; set; }

    }
}
