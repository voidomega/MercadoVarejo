using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class Funcionarios : BaseEntity
    {
        public Funcionarios()
        {
            HistoricoPedidos = new HashSet<HistoricoPedidos>();
        }

        [Key]
        public int IdFuncionario { get; set; }
        [StringLength(100)]
        public string CpfFuncionario { get; set; }
        [Required]
        [StringLength(25)]
        public string NmFuncionario { get; set; }
        [Required]
        [StringLength(32)]
        public string DsSenha { get; set; }
        [Required]
        [StringLength(12)]
        public string DsNmUsuario { get; set; }
        [Required]
        [StringLength(256)]
        public string DsEmail { get; set; }
        public bool FgDesativado { get; set; }

        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<HistoricoPedidos> HistoricoPedidos { get; set; }
    }
}
