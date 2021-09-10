using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class EnderecoClientes : BaseEntity
    {
        [Key]
        public int IdEnderecoCliente { get; set; }
        public int IdCliente { get; set; }
        public int? IdTipoEndereco { get; set; }
        [StringLength(512)]
        public string DsEndereco { get; set; }
        [StringLength(10)]
        public string DsNrEndereco { get; set; }
        [StringLength(80)]
        public string DsComplemento { get; set; }
        public int? IdUf { get; set; }
        public int? IdCidade { get; set; }
        public bool FgEnderecoEntrega { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Clientes.EnderecoClientes))]
        public virtual Clientes IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdTipoEndereco))]
        [InverseProperty(nameof(TipoEnderecos.EnderecoClientes))]
        public virtual TipoEnderecos IdTipoEnderecoNavigation { get; set; }
    }
}
