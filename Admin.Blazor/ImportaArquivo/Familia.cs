using System;
using System.Collections.Generic;
using System.Text;

namespace ImportaArquivo
{
    public class Familia
    {
        public string IdFamilia { get; set; }
        public string DesFamilia { get; set; }        
        public string IdCategoria { get; set; }


        public List<ImportCollumns> LstImportCollumns { get; set; }


    }
}
