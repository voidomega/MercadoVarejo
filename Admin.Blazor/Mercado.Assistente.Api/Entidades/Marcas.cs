using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class Marcas : BaseEntity
    {
        public Marcas()
        {
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        public int IdMarca { get; set; }
        [Required]
        [StringLength(100)]
        public string DsMarca { get; set; }

        [InverseProperty("IdMarcaNavigation")]
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
