using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class Clientes : BaseEntity
    {
        public Clientes()
        {
            EnderecoClientes = new HashSet<EnderecoClientes>();
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int IdCliente { get; set; }
        
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        
        [Required]
        [StringLength(25)]
        public string NmCliente { get; set; }
        
        [StringLength(256)]
        public string DsRazaoSocial { get; set; }
        
        [StringLength(20)]
        public string DsNrInscEstadual { get; set; }
        
        [Required]
        [StringLength(32)]
        public string DsSenha { get; set; }
        
        [Required]
        [StringLength(256)]
        public string DsEmail { get; set; }
        
        [Required]
        [StringLength(12)]
        public string DsNmUsuario { get; set; }
        
        public bool FgDesativado { get; set; }
        

        [InverseProperty("IdClienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<EnderecoClientes> EnderecoClientes { get; set; }

        [InverseProperty("IdClienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<Pedidos> Pedidos { get; set; }

    }
}
