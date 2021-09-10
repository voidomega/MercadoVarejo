using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            HistoricoPedidos = new HashSet<HistoricoPedidos>();
        }

        [Display(Name="ID",Description="ID funcionário")]
        [Key]
        public int IdFuncionario { get; set; }
        
        [Display(Name="Cpf",Description="Cpf do funcionário")]
        [StringLength(100)]
        public string CpfFuncionario { get; set; }
        
        [Display(Name="Nome",Description="Nome do funcionário")]
        [StringLength(25)]
        [Required]
        public string NmFuncionario { get; set; }
        
        [Display(Name="Senha",Description="Senha")]
        [Required]
        [StringLength(32)]
        public string DsSenha { get; set; }
        
        [Display(Name="Usúario",Description="Nome do Usuário do funcionário")]
        [Required]
        [StringLength(12)]
        public string DsNmUsuario { get; set; }
        
        [Display(Name="Email",Description="Email do funcionário")]
        [Required]
        [StringLength(256)]
        public string DsEmail { get; set; }
        
        [Display(Name="Desativado",Description="Desativado")]
        public bool FgDesativado { get; set; }
        

        [InverseProperty("IdFuncionarioNavigation")]
        [JsonIgnore]
        public virtual ICollection<HistoricoPedidos> HistoricoPedidos { get; set; }

    }
}
