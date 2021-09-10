using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class SituacaoPedidos : BaseEntity
    {
        public SituacaoPedidos()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int IdSituacaoPedidos { get; set; }
        
        [StringLength(50)]
        public string DsSituacaoPedidos { get; set; }
        

        [JsonIgnore]
        [InverseProperty("IdSituacaoPedidoNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }

    }
}
