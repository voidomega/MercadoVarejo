using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.MercadoAssistente.Api.Entidades
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

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.ImagensProduto))]
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
