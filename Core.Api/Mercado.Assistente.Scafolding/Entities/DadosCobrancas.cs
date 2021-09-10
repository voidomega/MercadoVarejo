using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class DadosCobrancas : BaseEntity
    {
        [Key]
        public long IdDadosCobranca { get; set; }
        
        public long? IdPedido { get; set; }
        
        public int? IdTipoCobranca { get; set; }
        
        [StringLength(512)]
        public string NrCartao { get; set; }
        
        [StringLength(512)]
        public string NmCartao { get; set; }
        
        [StringLength(100)]
        public string DsAutorizacao { get; set; }
        
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        
        [StringLength(6)]
        public string StCartao { get; set; }
        
        [Column(TypeName = "money")]
        public decimal VlPago { get; set; }
        

        [ForeignKey("IdPedido")]
        [InverseProperty("DadosCobrancas")]
        [JsonIgnore]
        public virtual Pedidos IdPedidoNavigation { get; set; }

        [ForeignKey("IdTipoCobranca")]
        [InverseProperty("DadosCobrancas")]
        [JsonIgnore]
        public virtual TipoCobranca IdTipoCobrancaNavigation { get; set; }

    }
}
