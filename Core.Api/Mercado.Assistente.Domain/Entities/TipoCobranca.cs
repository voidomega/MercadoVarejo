using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class TipoCobranca : BaseEntity
    {
        public TipoCobranca()
        {
            DadosCobrancas = new HashSet<DadosCobrancas>();
        }

        [Column("ITipoCobranca")]
        [Key]
        public int ItipoCobranca { get; set; }
        
        [Required]
        [StringLength(25)]
        public string DsTipoCobranca { get; set; }
        
        [Required]
        [StringLength(15)]
        public string FgTipoMoeda { get; set; }
        

        [InverseProperty("IdTipoCobrancaNavigation")]
        [JsonIgnore]
        public virtual ICollection<DadosCobrancas> DadosCobrancas { get; set; }

    }
}
