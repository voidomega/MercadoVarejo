using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class PromocaoProdutos
    {
        [Key]
        public int IdPromocaoProdutos { get; set; }
        
        public long? IdProduto { get; set; }
        
        [StringLength(3)]
        [Required]
        public string TpDesconto { get; set; }
        
        public decimal PctDesconto { get; set; }
        
        
        public decimal VlDesconto { get; set; }
        
        public DateTime DtInicioPromocao { get; set; }
        
        public DateTime? DtFimPromocao { get; set; }
        
        public int? IdCategoria { get; set; }
        
        public int? IdFamilia { get; set; }
        

        [JsonIgnore]
        [ForeignKey("IdCategoria")]
        [InverseProperty("PromocaoProdutos")]
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
