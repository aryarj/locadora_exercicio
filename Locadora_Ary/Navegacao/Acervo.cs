using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Locadora_Ary.Navegacao
{
    class Acervo
    {
        Formatacao ft = new Formatacao();
        public string Caminho()
        {
            // Estabelecendo o caminho para o arquivo de texto: Acervo
            return @"C:\Users\Administrador\source\repos\Locadora_Ary\Acervo.txt";

        }

        // Contando o número máximo de caracteres dos titulos dos filmes
        public int CountMaxCaract()
         {
            string path = Caminho();
            // Acessando o arquivo de texto: Acervo
            StreamReader sr2 = File.OpenText(path);
            int maxCarc = 0;
             while (!sr2.EndOfStream)
             {
                 string[] line = sr2.ReadLine().Split(',');
                 string titulo = line[1];

                // adicionando mais 40 caracteres ao título, para acomodar os outros campos (códigos, nomes, etc.)
                int carcNum = titulo.Count() + 40;

                // Armazenando o número máximo de caracteres
                 if (maxCarc < carcNum)
                 {
                     maxCarc = carcNum;
                 }

             }
             return maxCarc;
         }

        // Função para traçar as linhas horizontais das tabelas com base na função anterior 'CountMaxCaract()' 
        public void LinhaHorizontaL()
        {
            // Traçando as linhas horizontais da tabela
            ft.MargEsqu();
            for (int i = 1; i < CountMaxCaract() - 1; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }

        //Imprimindo o cabeçalho inferior
        public void CabecaInferior()
        {
            ft.MargEsqu();
            Console.Write(ft.Caracter() + "  Código do filme  " + ft.Caracter() + "  Título");
            int conta5 = (ft.Caracter() + "  Código do filme  "+ ft.Caracter() +"  Título").Count();
            int conta6 = CountMaxCaract() - conta5-2;
            //Traçando as linhas verticais
            for (int i = 1; i < conta6; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());
        }
        
        public void ListaAcervo()
        {

            // Acessando o arquivo de texto: Acervo
            string path = Caminho();
                  
            // Traçando as linhas horizontais da tabela
            LinhaHorizontaL();
            
            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter()+"  \t\tAcervo Completo");
            int conta3 = (ft.Caracter()+"  \t\tAcervo Completo").Count();
            int conta4 = CountMaxCaract() - conta3 - 13;
            for (int i = 1; i < conta4; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            LinhaHorizontaL();

            //Imprimindo o cabeçalho inferior
            CabecaInferior();

            // Traçando as linhas horizontais da tabela
            LinhaHorizontaL();
            
            //Coletando e imprimindo o conteúdo e traçando as linhas verticais
            StreamReader sr = File.OpenText(path);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string titulo = line[1];

                // Para códigos de filme de um digito
                if (codigo < 10)
                {
                    int conta = (ft.Caracter()+"\t" + codigo + " . . ." + titulo).Count();
                    int conta2 = CountMaxCaract() - conta-8;
                    ft.MargEsqu();
                    Console.Write(ft.Caracter()+"\t" + codigo + " . . ." + titulo);
                    for(int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());
                }
                // Para códigos de filme de dois digitos
                if (codigo >= 10)
                {
                    int conta = (ft.Caracter()+"\t" + codigo + " . . ." + titulo).Count();
                    int conta2 = CountMaxCaract() - conta-8;
                    ft.MargEsqu();
                    Console.Write(ft.Caracter()+"\t" + codigo + " . . " + titulo);
                    for (int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(" "+ ft.Caracter());
                }


            }

            // Traçando as linhas horizontais da tabela
            LinhaHorizontaL();
                        
            ft.MargEsqu();
            Console.Write("Digite uma opção do menu: ");
           
            

        }
        
         
            
    }
}
