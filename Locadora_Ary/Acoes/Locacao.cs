using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Locadora_Ary.Navegacao;
using System.Globalization;
using System.Linq;

namespace Locadora_Ary.Acoes
{
    // Herança com a classe 'Devolução'
    class Locacao : Devolucao
    {
        public DateTime DataLoca { get; set; }

        public Locacao()
        {
        }

        // Acrescentando o atributo da data de locação 'DataLoca' 
        public Locacao(int codigoCli, DateTime dataDevol, int codigoFilm, DateTime dataLoca) : base(codigoCli, dataDevol, codigoFilm)
        {
            DataLoca = dataLoca;
        }

        // Estabelecendo a função 'Locar'
        public void Locar(int codigoCli, int codigoFilm, DateTime dataLoca)
        {
            //Declarando as classes one estão funções que serão utilizadas aqui
            Acervo ac = new Acervo();
            Clientes cl = new Clientes();
            Formatacao ft = new Formatacao();

            //Acessando os arquivos de texto 'Acervo' e 'Clientes' 
            StreamReader sr = File.OpenText(ac.Caminho());
            StreamReader srCli = File.OpenText(cl.CaminhoCli());

            // Lendo e armazenando os dados dos clientes
            while (!srCli.EndOfStream)
            {
                string[] lineCli = srCli.ReadLine().Split(',');
                int codigocli2 = int.Parse(lineCli[0]);
                string nomeCli2 = lineCli[1];

                // Selecionando o cliente em questão
                if (codigoCli.Equals(codigocli2))
                {
                    Console.WriteLine();
                    ft.MargEsqu();
                    Console.WriteLine("Codigo do cliente: " + codigocli2);
                    ft.MargEsqu();
                    Console.WriteLine("Cliente: " + nomeCli2);
                }
            }

            // Lendo e armazenando os dados do acervo
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string titulo = line[1];
                string cliente = line[3];

                // Verificando se o filme está disponível para locação
                if (codigoFilm.Equals(codigo) && cliente == "")
                {

                    Console.WriteLine();

                    // Traçando uma linha horizontal
                    ac.LinhaHorizontaL();

                    // Estando disponível, as informações do filme e do cliente serão apresentados para conferência
                    ft.MargEsqu();
                    Console.Write(ft.Caracter() + " Código do filme /       Título        /  Data da Locação ");
                    int conta5 = (ft.Caracter() + " Código do filme /       Título        /  Data da Locação ").Count();
                    int conta6 = ac.CountMaxCaract() - conta5 - 2;
                    for (int i = 1; i < conta6; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());

                    // Traçando uma linha horizontal
                    ac.LinhaHorizontaL();

                    int conta = (ft.Caracter() + "\t" + codigoFilm + " . . ." + titulo+"     "+ dataLoca.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).Count();
                    int conta2 = ac.CountMaxCaract() - conta - 8;
                    ft.MargEsqu();
                    Console.Write(ft.Caracter() + "\t" + codigoFilm + " . . ." + titulo + "     " + dataLoca.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    for (int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());

                    // Traçando uma linha horizontal
                    ac.LinhaHorizontaL();

                    // Confirmar ou não a locação
                    Console.WriteLine();
                    ft.MargEsqu();
                    Console.WriteLine("Confirma as informações? (s =sim e n=não)");
                    ft.MargEsqu();
                    char opcao = char.Parse(Console.ReadLine());
                    if (opcao == 's' || opcao == 'S')
                    {
                        ft.MargEsqu();
                        Console.WriteLine("Informação gravada com sucesso!");
                        ft.MargEsqu();
                        Console.Write("Digite uma opção do menu: ");
                        break;
                    }
                    else
                    {
                        ft.MargEsqu();
                        Console.WriteLine("Informação descartada");
                        ft.MargEsqu();
                        Console.Write("Digite uma opção do menu: ");
                        break;
                    }

                }
                
                //Caso o filme já tenha sido locado
                if (codigoFilm.Equals(codigo) && cliente != "")
                {
                    Console.WriteLine();
                    ft.MargEsqu();
                    Console.WriteLine("Esse filme já está locado, sinto muito");
                    Console.WriteLine();
                    ft.MargEsqu();
                    Console.Write("Digite uma opção do menu: ");
                }

                
            }
            

        }
    }
}
