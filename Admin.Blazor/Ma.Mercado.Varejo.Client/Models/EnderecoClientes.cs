using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class EnderecoClientes
    {
        [Key]
        public int IdEnderecoCliente { get; set; }
        
        [Display(Name="Id Cliente",Description="Id Cliente")]
        public int IdCliente { get; set; }
        
        [Display(Name="Tipo Endereço",Description="Tipo Endereço")]
        public int? IdTipoEndereco { get; set; }
        
        [Display(Name="Logradouro",Description="Logradouro")]
        [StringLength(512)]
        public string DsEndereco { get; set; }
        
        [Display(Name="Nº",Description="Número")]
        [StringLength(10)]
        public string DsNrEndereco { get; set; }
        
        [Display(Name="Complemento",Description="Complemento endereço")]
        [StringLength(80)]
        public string DsComplemento { get; set; }
        
        [Display(Name="Estado",Description="UF do estado")]
        public int? IdUf { get; set; }
        
        [Display(Name="Cidade",Description="ID da Cidade")]
        public int? IdCidade { get; set; }
        
        [Display(Name="Entrega",Description="Endereço de entrega")]
        public bool FgEnderecoEntrega { get; set; }
        

        [JsonIgnore]
        [InverseProperty("EnderecoClientes")]
        [ForeignKey("IdCliente")]
        public virtual Clientes IdClienteNavigation { get; set; }

        [ForeignKey("IdTipoEndereco")]
        [InverseProperty("EnderecoClientes")]
        [JsonIgnore]
        public virtual TipoEnderecos IdTipoEnderecoNavigation { get; set; }

    }
}
