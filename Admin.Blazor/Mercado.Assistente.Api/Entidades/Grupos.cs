using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ma.MercadoAssistente.Api.Entidades
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

        [JsonIgnore]
        [InverseProperty("IdGrupoNavigation")]
        public virtual ICollection<Categorias> Categorias { get; set; }
    }
}
