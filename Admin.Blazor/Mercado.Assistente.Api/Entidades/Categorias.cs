using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ma.MercadoAssistente.Api.Entidades
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

        [JsonIgnore]
        [ForeignKey(nameof(IdGrupo))]
        [InverseProperty(nameof(Grupos.Categorias))]
        public virtual Grupos IdGrupoNavigation { get; set; }
        [InverseProperty("IdCategoriaNavigation")]
        [JsonIgnore]
        public virtual ICollection<Familias> Familias { get; set; }
        [InverseProperty("IdCategoriaNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }
    }
}
