using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class Categorias : BaseEntity
    {
        public Categorias()
        {
            Familias = new HashSet<Familias>();
            PromocaoProdutos = new HashSet<PromocaoProdutos>();
        }

        [Key]
        public int IdCategoria { get; set; }
        
        [StringLength(256)]
        public string DsCategoria { get; set; }
        
        public int? IdGrupo { get; set; }
        

        [ForeignKey("IdGrupo")]
        [InverseProperty("Categorias")]
        [JsonIgnore]
        public virtual Grupos IdGrupoNavigation { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        [JsonIgnore]
        public virtual ICollection<Familias> Familias { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }

    }
}
