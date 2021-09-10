using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class Grupos : BaseEntity
    {
        public Grupos()
        {
            Categorias = new HashSet<Categorias>();
        }

        [Key]
        public int IdGrupo { get; set; }
        
        [StringLength(150)]
        public string DsGrupo { get; set; }
        

        [InverseProperty("IdGrupoNavigation")]
        [JsonIgnore]
        public virtual ICollection<Categorias> Categorias { get; set; }

    }
}
