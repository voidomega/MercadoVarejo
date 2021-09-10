using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.MercadoAssistente.Api.Entidades
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

        [InverseProperty("IdSituacaoPedidoNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
