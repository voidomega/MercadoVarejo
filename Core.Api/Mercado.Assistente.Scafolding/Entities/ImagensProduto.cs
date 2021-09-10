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
        
        [Required]
        [StringLength(512)]
        public string DsCaminhoImagem { get; set; }
        
        [StringLength(25)]
        public string GfTipoImagem { get; set; }
        
        public long IdProduto { get; set; }
        

        [ForeignKey("IdProduto")]
        [InverseProperty("ImagensProduto")]
        [JsonIgnore]
        public virtual Produtos IdProdutoNavigation { get; set; }

    }
}
