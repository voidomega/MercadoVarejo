using System;
using System.Collections.Generic;
using System.Text;

namespace ImportaArquivo
{
    
    public class Categoria
    {
        public string IdCategoria { get; set; }
        public string DesCategoria { get; set; }
        public string IdGrupo { get; set; }

        public List<Familia> Familias { get; set; }
    }
}
