using System;
using System.Collections.Generic;
using System.Text;

namespace ImportaArquivo
{
    public class CentroReceita
    {
        public string IdCentroReceita { get; set; }
        public string DesCentroReceita { get; set; }

        public List<Grupo> Grupos  { get;set; }
    }
}
