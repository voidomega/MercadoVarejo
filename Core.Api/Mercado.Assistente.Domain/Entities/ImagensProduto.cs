using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ma.Domain.Entities;

namespace Mercado.Assistente.Domain.Entities
{
    public partial class ImagensProduto : BaseEntity
    {
        [Key]
        public long IdImagenProduto { get; set; }
        
        [Display(Name="Caminho",Description="Caminho da imagem")]
        [StringLength(512)]
        [Required]
        public string DsCaminhoImagem { get; set; }
        
        [Display(Name="Tipo",Description="Tipo da imagem")]
        [StringLength(25)]
        public string GfTipoImagem { get; set; }
        
        [Display(Name="Produto",Description="Id do Produto")]
        public long IdProduto { get; set; }
        

        [JsonIgnore]
        [ForeignKey("IdProduto")]
        [InverseProperty("ImagensProduto")]
        public virtual Produtos IdProdutoNavigation { get; set; }

    }
}
