using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Ma.MercadoAssistente.Api.Entidades
{
    public partial class TipoCobranca : BaseEntity
    {
        public TipoCobranca()
        {
            DadosCobrancas = new HashSet<DadosCobrancas>();
        }

        [Key]
        [Column("ITipoCobranca")]
        public int ItipoCobranca { get; set; }
        [Required]
        [StringLength(25)]
        public string DsTipoCobranca { get; set; }
        [Required]
        [StringLength(15)]
        public string FgTipoMoeda { get; set; }

        [InverseProperty("IdTipoCobrancaNavigation")]
        public virtual ICollection<DadosCobrancas> DadosCobrancas { get; set; }
    }
}
