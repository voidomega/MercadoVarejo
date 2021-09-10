using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            Categorias = new HashSet<Categorias>();
        }

        [Display(Name = "ID",Description="Id do Grupo" )]
        [Key]
        public int IdGrupo { get; set; }
        
        [Display(Name = "Descrição",Description="Descrição do Grupo" )]
        [StringLength(150)]
        public string DsGrupo { get; set; }
        

        [Display(Name="Categorias",Description="Categorias")]
        [JsonIgnore]
        [InverseProperty("IdGrupoNavigation")]
        public virtual ICollection<Categorias> Categorias { get; set; }

    }
}
