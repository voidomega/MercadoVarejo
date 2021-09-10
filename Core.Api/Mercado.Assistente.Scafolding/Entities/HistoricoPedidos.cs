using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class HistoricoPedidos : BaseEntity
    {
        [Key]
        public int IdHistoricoPedido { get; set; }
        
        public long IdPedido { get; set; }
        
        [StringLength(512)]
        public string DsObsHistoricoPedido { get; set; }
        
        public DateTime DtHoraStatus { get; set; }
        
        public int IdFuncionario { get; set; }
        

        [ForeignKey("IdFuncionario")]
        [InverseProperty("HistoricoPedidos")]
        [JsonIgnore]
        public virtual Funcionarios IdFuncionarioNavigation { get; set; }

        [ForeignKey("IdPedido")]
        [InverseProperty("HistoricoPedidos")]
        [JsonIgnore]
        public virtual Pedidos IdPedidoNavigation { get; set; }

    }
}
