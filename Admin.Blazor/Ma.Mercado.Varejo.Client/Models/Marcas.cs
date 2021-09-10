using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class Marcas
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
