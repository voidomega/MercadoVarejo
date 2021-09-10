using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class PromocaoProdutos : BaseEntity
    {
        [Key]
        public int IdPromocaoProdutos { get; set; }
        
        public long? IdProduto { get; set; }
        
        [Required]
        [StringLength(3)]
        public string TpDesconto { get; set; }
        
        [Column(TypeName = "numeric(18,0)")]
        public decimal PctDesconto { get; set; }
        
        [Column(TypeName = "numeric(18,0)")]
        public decimal VlDesconto { get; set; }
        
        public DateTime DtInicioPromocao { get; set; }
        
        public DateTime? DtFimPromocao { get; set; }
        
        public int? IdCategoria { get; set; }
        
        public int? IdFamilia { get; set; }
        

        [ForeignKey("IdCategoria")]
        [InverseProperty("PromocaoProdutos")]
        [JsonIgnore]
        public virtual Categorias IdCategoriaNavigation { get; set; }

        [ForeignKey("IdFamilia")]
        [InverseProperty("PromocaoProdutos")]
        [JsonIgnore]
        public virtual Familias IdFamiliaNavigation { get; set; }

        [ForeignKey("IdProduto")]
        [InverseProperty("PromocaoProdutos")]
        [JsonIgnore]
        public virtual Produtos IdProdutoNavigation { get; set; }

    }
}
