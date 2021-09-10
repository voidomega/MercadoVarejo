using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class TipoEnderecos :BaseEntity
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
        public virtual ICollection<EnderecoClientes> EnderecoClientes { get; set; }
    }
}
