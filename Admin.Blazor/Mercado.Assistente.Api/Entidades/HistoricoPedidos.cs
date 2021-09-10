using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
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

        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(Funcionarios.HistoricoPedidos))]
        public virtual Funcionarios IdFuncionarioNavigation { get; set; }
        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(Pedidos.HistoricoPedidos))]
        public virtual Pedidos IdPedidoNavigation { get; set; }
    }
}
