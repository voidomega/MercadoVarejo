using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ma.Mercado.Varejo.Models
{
    public partial class TipoEnderecos
    {
        public TipoEnderecos()
        {
            EnderecoClientes = new HashSet<EnderecoClientes>();
        }

        [Key]
        public int IdTipoEndereco { get; set; }
        
        [StringLength(100)]
        public string DsTipoEndereco { get; set; }
        

        [JsonIgnore]
        [InverseProperty("IdTipoEnderecoNavigation")]
        public virtual ICollection<EnderecoClientes> EnderecoClientes { get; set; }

    }
}
