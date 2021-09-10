using System;
using System.Collections.Generic;
using System.Text;

namespace ImportaArquivo
{
    public class Grupo
    {
        public string IdGrupo { get; set; }
        public string DesGrupo { get; set; }
        public string IdCentroReceita { get; set; }

        public List<Categoria> Categorias { get; set; }
    }
}
