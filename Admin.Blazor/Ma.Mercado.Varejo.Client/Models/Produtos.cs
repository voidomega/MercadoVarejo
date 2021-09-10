using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            ImagensProduto = new HashSet<ImagensProduto>();
            ItemPedidos = new HashSet<ItemPedidos>();
            PromocaoProdutos = new HashSet<PromocaoProdutos>();
        }

        [Display(Name="Produto",Description="Id Produto")]
        [Key]
        public long IdProduto { get; set; }
        
        [Display(Name="Nome",Description="Nome do produto")]
        [StringLength(512)]
        public string NmProduto { get; set; }
        
        [Display(Name="Marca",Description="Id da Marca")]
        public int IdMarca { get; set; }
        
        [Display(Name="Descrição curta",Description="Descrição curta")]
        [StringLength(80)]
        public string DsCurtaProduto { get; set; }
        
        [Display(Name="Observação",Description="Observação")]
        [StringLength(4000)]
        public string DsObsProduto { get; set; }
        
        [Display(Name="Unidade",Description="Unidade")]
        [StringLength(25)]
        public string DsUnidade { get; set; }
        
        
        [Display(Name="Desconto",Description="Valaor do Desconto")]
        public decimal? VlDesconto { get; set; }
        
        
        [Display(Name="Preço",Description="Valor do Preço")]
        public decimal? VlPreco { get; set; }
        
        [Column("date")]
        [Display(Name="Início Desconto",Description="Data Inicial do Desconto")]
        public DateTime? DtIniValidadeDesconto { get; set; }
        
        [Column("date")]
        [Display(Name="Final Desconto",Description="Data Final do Desconto")]
        public DateTime? DtFimValidadeDesconto { get; set; }
        
        
        [Display(Name="Qtd. Un.",Description="Quantidade por Unidade")]
        public decimal? VlQtdUnidade { get; set; }
        
        [Display(Name="Tipo Desc.",Description="Tipo de Desconto")]
        [StringLength(25)]
        public string TpDesconto { get; set; }
        
        [Display(Name="Familia",Description="Id da Familia")]
        public int? IdFamilia { get; set; }
        

        [JsonIgnore]
        [InverseProperty("Produtos")]
        [ForeignKey("IdFamilia")]
        public virtual Familias IdFamiliaNavigation { get; set; }

        [ForeignKey("IdMarca")]
        [InverseProperty("Produtos")]
        [JsonIgnore]
        public virtual Marcas IdMarcaNavigation { get; set; }

        [InverseProperty("IdProdutoNavigation")]
        [JsonIgnore]
        public virtual ICollection<ImagensProduto> ImagensProduto { get; set; }

        [InverseProperty("IdProdutoNavigation")]
        [JsonIgnore]
        public virtual ICollection<ItemPedidos> ItemPedidos { get; set; }

        [InverseProperty("IdProdutoNavigation")]
        [JsonIgnore]
        public virtual ICollection<PromocaoProdutos> PromocaoProdutos { get; set; }

    }
}
