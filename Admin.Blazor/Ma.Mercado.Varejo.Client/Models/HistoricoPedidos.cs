using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class HistoricoPedidos
    {
        [Key]
        public int IdHistoricoPedido { get; set; }
        
        [Display(Name="Pedido",Description="Id do Pedido")]
        public long IdPedido { get; set; }
        
        [Display(Name="Observação",Description="Observação")]
        [StringLength(512)]
        public string DsObsHistoricoPedido { get; set; }
        
        [Display(Name="Hora",Description="Data e Hora do Historico")]
        public DateTime DtHoraStatus { get; set; }
        
        [Display(Name="Funcionário",Description="Id do Funcionário")]
        public int IdFuncionario { get; set; }
        

        [JsonIgnore]
        [InverseProperty("HistoricoPedidos")]
        [ForeignKey("IdFuncionario")]
        public virtual Funcionarios IdFuncionarioNavigation { get; set; }

        [ForeignKey("IdPedido")]
        [InverseProperty("HistoricoPedidos")]
        [JsonIgnore]
        public virtual Pedidos IdPedidoNavigation { get; set; }

    }
}
