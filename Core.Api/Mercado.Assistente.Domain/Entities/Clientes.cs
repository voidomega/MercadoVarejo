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

        [Display(Name="Id",Description="Id do Cliente")]
        [Key]
        public int IdCliente { get; set; }
        
        [Display(Name="Cpf-Cnpj",Description="CPF ou CNPJ")]
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        
        [Display(Name="Nome",Description="Nome do Cliente")]
        [StringLength(25)]
        [Required]
        public string NmCliente { get; set; }
        
        [Display(Name="Razão Social",Description="Razão Social do Cliente")]
        [StringLength(256)]
        public string DsRazaoSocial { get; set; }
        
        [Display(Name="Nº Insc. Estadual",Description="Número da Inscrição Estadual")]
        [StringLength(20)]
        public string DsNrInscEstadual { get; set; }
        
        [Display(Name="Senha",Description="Senha")]
        [Required]
        [StringLength(32)]
        public string DsSenha { get; set; }
        
        [Display(Name="Email",Description="Email do Cliente")]
        [Required]
        [StringLength(256)]
        public string DsEmail { get; set; }
        
        [Display(Name="Usuário",Description="Nome do usuário para login no Sistema")]
        [Required]
        [StringLength(12)]
        public string DsNmUsuario { get; set; }
        
        [Display(Name="Desativado",Description="Desativa o Cliente")]
        public bool FgDesativado { get; set; }
        

        [InverseProperty("IdClienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<EnderecoClientes> EnderecoClientes { get; set; }

        [InverseProperty("IdClienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<Pedidos> Pedidos { get; set; }

    }
}
