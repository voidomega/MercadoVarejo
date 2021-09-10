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

        [Display(Name="Id",Description="Id Categoria")]
        [Key]
        public int IdCategoria { get; set; }
        
        [Display(Name="Descrição",Description="Descrição da Categoria")]
        [StringLength(256)]
        public string DsCategoria { get; set; }
        
        public int? IdGrupo { get; set; }
        

        [JsonIgnore]
        [InverseProperty("Categorias")]
        [ForeignKey("IdGrupo")]
        public virtual Grupos IdGrupoNavigation { get; set; }

        [JsonIgnore]
        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Familias> Familias { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }

    }
}
