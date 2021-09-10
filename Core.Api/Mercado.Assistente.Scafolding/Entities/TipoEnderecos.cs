using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class TipoEnderecos : BaseEntity
    {
        public TipoEnderecos()
        {
            EnderecoClientes = new HashSet<EnderecoClientes>();
        }

        [Key]
        public int IdTipoEndereco { get; set; }
        
        [StringLength(100)]
        public string DsTipoEndereco { get; set; }
        

        [InverseProperty("IdTipoEnderecoNavigation")]
        [JsonIgnore]
        public virtual ICollection<EnderecoClientes> EnderecoClientes { get; set; }

    }
}
