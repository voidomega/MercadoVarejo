using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
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
        

        [ForeignKey("IdCliente")]
        [InverseProperty("EnderecoClientes")]
        [JsonIgnore]
        public virtual Clientes IdClienteNavigation { get; set; }

        [ForeignKey("IdTipoEndereco")]
        [InverseProperty("EnderecoClientes")]
        [JsonIgnore]
        public virtual TipoEnderecos IdTipoEnderecoNavigation { get; set; }

    }
}
