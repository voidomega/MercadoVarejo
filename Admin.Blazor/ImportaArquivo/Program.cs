using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportaArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathArq = @"C:\Users\andreluc\OneDrive\Área de Trabalho\RelProdutosXtra.25.09.20.csv";

            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            int counter = 0;
            string line;

            bool startRead = false;

            int idFamilia = 25000;


            CentroReceita centro = new CentroReceita();
            centro.Grupos = new List<Grupo>();
            Grupo grupo = new Grupo();
            grupo.Categorias = new List<Categoria>();


            Categoria categoria = new Categoria();
            categoria.Familias = new List<Familia>();

            Familia familia = new Familia();
            familia.LstImportCollumns = new List<ImportCollumns>();

            var encoding = System.Text.Encoding.GetEncoding(1252);

            System.IO.StreamReader file = new System.IO.StreamReader(pathArq, encoding);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);

                if(!startRead && line == "Cód. Prod.;BP;Barra;;Cód. FV;Descrição PDV;;;QTD;ICMS;Estoque;Preço Custo;;Preço Venda;Margem Param;;Total Custo;;;Total Venda")
                {
                    startRead = true;
                }

                if(startRead)
                {
                    string[] colunas = line.Split(";".ToCharArray());

                    int qtdCol = colunas.Length;

                    if(qtdCol==20)
                    {
                        if (colunas[0].StartsWith("Centro de Receita:"))
                        {
                            centro.IdCentroReceita = "1";
                            centro.DesCentroReceita = colunas[0].Replace("Centro de Receita:", "");
                        }

                        if (colunas[0].StartsWith("Grupo:"))
                        {
                            Grupo novoGrupo = new Grupo();
                            novoGrupo.Categorias = new List<Categoria>();

                            string[] grupoData = colunas[0].Replace("Grupo:", "").Split("-".ToCharArray());
                            novoGrupo.IdGrupo = grupoData[0];
                            novoGrupo.DesGrupo = grupoData[1];
                            novoGrupo.IdCentroReceita = "1";                            

                            if (grupo.IdGrupo != novoGrupo.IdGrupo)
                            {

                                if (string.IsNullOrWhiteSpace(grupo.IdGrupo)) grupo = novoGrupo;

                                centro.Grupos.Add(grupo);
                                grupo = novoGrupo;
                            }
                        }
                        else if (colunas[0].StartsWith("Categoria:"))
                        {
                            Categoria novoCategoria = new Categoria();
                            novoCategoria.Familias = new List<Familia>();

                            string[] categoriaData = colunas[0].Replace("Categoria:", "").Split("-".ToCharArray());
                            novoCategoria.IdCategoria = categoriaData[0];
                            novoCategoria.DesCategoria = categoriaData[1];
                            novoCategoria.IdGrupo = grupo.IdGrupo;

                           

                            if (categoria.IdCategoria != novoCategoria.IdCategoria)
                            {
                                if (string.IsNullOrWhiteSpace(categoria.IdCategoria)) categoria = novoCategoria;

                                grupo.Categorias.Add(categoria);
                                categoria = novoCategoria;
                            }

                        }
                        else if (colunas[0].StartsWith("Família:"))
                        {
                            Familia novoFamilia = new Familia();
                            novoFamilia.LstImportCollumns = new List<ImportCollumns>();

                            string[] FamiliaData = colunas[0].Replace("Família:", "").Split("-".ToCharArray());
                            novoFamilia.IdFamilia = FamiliaData[0];
                            novoFamilia.DesFamilia = FamiliaData[1];
                            novoFamilia.IdCategoria = categoria.IdCategoria;


                            if (novoFamilia.IdFamilia.Trim().Length == 0)
                            {
                                novoFamilia.IdFamilia = idFamilia.ToString();
                                idFamilia++;
                            }

                            if (novoFamilia.DesFamilia.Trim().Length == 0)
                            {
                                novoFamilia.DesFamilia = "Família base do Grupo: " + grupo.DesGrupo;
                            }



                                if (familia.IdFamilia != novoFamilia.IdFamilia)
                            {
                                if (string.IsNullOrWhiteSpace(familia.IdFamilia)) familia = novoFamilia;

                                categoria.Familias.Add(familia);
                                familia = novoFamilia;
                            }
                            //idFamilia;

                            // linha eh registro de dados
                        }else if(int.TryParse(colunas[0], out _))
                        {
                            ImportCollumns importCollumns = new ImportCollumns();
                            importCollumns.IdFamilia = familia.IdFamilia;

                            importCollumns.CodProd = colunas[0];
                            importCollumns.BP = colunas[1];

                            importCollumns.Barra = colunas[2];

                            importCollumns.Dados01 = colunas[3];

                            importCollumns.CodFV = colunas[4];
                            importCollumns.DescricaoPDV = colunas[5];

                            importCollumns.Dados02 = colunas[6];
                            importCollumns.Dados03 = colunas[7];

                            importCollumns.Qtd = colunas[8];
                            importCollumns.Icms = colunas[9];
                            importCollumns.Estoque = colunas[10];
                            importCollumns.PrecoCusto = colunas[11];
                            importCollumns.Dados04 = colunas[12];

                            importCollumns.PrecoVenda = colunas[13];
                            importCollumns.MargemParam = colunas[14];
                            importCollumns.Dados05 = colunas[15];

                            importCollumns.TotalCusto = colunas[16];
                            importCollumns.Dados06 = colunas[17];
                            importCollumns.Dados07 = colunas[18];

                            importCollumns.TotalVenda = colunas[19];

                            familia.LstImportCollumns.Add(importCollumns);
                            //     0        1    2  3     4      5         67 8   9    10        11      12    13          14      15   16      17 18   19
                            // "Cód. Prod.;BP;Barra;;Cód. FV;Descrição PDV;;;QTD;ICMS;Estoque;Preço Custo;;Preço Venda;Margem Param;;Total Custo;;;Total Venda")

                        }
                    }


                }

                counter++;
            }

            file.Close();

            string dirSave = System.IO.Path.GetDirectoryName(pathArq);


            string fileSave = System.IO.Path.Combine(dirSave, "Result.json");

            string jsonSave = JsonConvert.SerializeObject(centro);
            System.IO.File.WriteAllText(fileSave,jsonSave);

            if (System.IO.File.Exists(fileSave))
                Console.WriteLine("Fim do processo.");

            System.Environment.Exit(0);
        }
    }
}
