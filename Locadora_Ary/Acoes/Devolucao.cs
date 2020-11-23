using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Locadora_Ary.Navegacao;
using System.Globalization;
using System.Linq;

namespace Locadora_Ary.Acoes
{
    class Devolucao
    {
        //Declarando as classes 'Acervo' e 'Formatação'
        Formatacao ft = new Formatacao();
        Acervo ac = new Acervo();

        public int CodigoCli { get; set; }
        public DateTime DataDevol { get; set; }
        public int CodigoFilm { get; set; }

        public Devolucao()
        {
        }

        public Devolucao(int codigoCli, DateTime dataDevol, int codigoFilm)
        {
            CodigoCli = codigoCli;
            DataDevol = dataDevol;
            CodigoFilm = codigoFilm;
        }

        public void LinhaHorizontaEL()
        {
            // Traçando as linhas horizontais extra large da tabela
            Console.Write("\t");
            for (int i = 1; i < ac.CountMaxCaract() +47; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }

        //Método para imprimir os dados da devolução dos filmes e os cálculo total das diárias
        public void Calculo(int codigoCli,DateTime dataDevol,int codigoFilm)
        {
            // Acessando o arquivo de texto: 'Acervo', cujo 
            //endereçco 'caminho' está na classe 'Acervo'
            StreamReader sr = File.OpenText(ac.Caminho());

            //Criando o acabeçalho
            Console.WriteLine();
            ft.MargEsqu();
            Console.WriteLine("Calculo da Locação:");
            Console.WriteLine();
            
            // Traçando uma linha horizontal
            LinhaHorizontaEL();

            //Formatando o cabeçalho inferior
            Console.Write("\t");
            Console.Write(ft.Caracter() + "    Título     /     Cliente        /  Data da Retirada  /  Data devolução  /  Locação por dia  /  Total dias  / Valor  ");
            int conta5 = (ft.Caracter() + "    Título     /     Cliente        /  Data da Retirada  /  Data devolução  /  Locação por dia  /  Total dias  / Valor  ").Count();
            int conta6 = ac.CountMaxCaract() - conta5 - 2;
            for (int i = 1; i < conta6; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            LinhaHorizontaEL();

            //zerando um somador
            double soma = 0;
            while (!sr.EndOfStream)
            {
                //Lendo e selecionando os dados do arquivo 'Acervo'
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string titulo = line[1];
                int codigo2 = int.Parse(line[2]);
                string cliente = line[3];
                DateTime data = DateTime.Parse(line[4]);

                //Calculo do tempo de locação dos filmes e o valor do serviço
                if (codigo2.Equals(codigoCli))
                {
                    //Armazenando a data de hoje
                    int day = dataDevol.Day;
                    int month = dataDevol.Month;

                    //Armazenando a data de locação
                    int day2 = data.Day;
                    int month2 = data.Month;

                    //Cálculo do tempo total de locação
                    int totalTime = day - day2 + (month - month2) * 30;
                    double valorLocacao = 5.5;
                    double result = totalTime * valorLocacao;
                    
                    //Somando as locações devidas
                    soma += result;

                    //Formatando o corpo
                    int conta = (ft.Caracter() + " " + titulo + ", " + cliente + ", " + data.ToString("dd / MM / yyyy", CultureInfo.InvariantCulture) + "..,.."
                        + dataDevol.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ", " + "R$ " + valorLocacao.ToString("F2", CultureInfo.InvariantCulture)
                        + ", " + (totalTime) + " dias, " + "valor Total da Locação R$: " + result.ToString("F2", CultureInfo.InvariantCulture)).Count();
                    int conta2 = ac.CountMaxCaract() - conta + 46;
                    Console.Write("\t");
                    Console.Write(ft.Caracter() + " " + titulo + ", " + cliente + ", " + data.ToString("dd / MM / yyyy", CultureInfo.InvariantCulture)+"..,.."
                        + dataDevol.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ", " + "R$ " + valorLocacao.ToString("F2", CultureInfo.InvariantCulture)
                        + ", " + (totalTime) + " dias, " + "valor Total da Locação R$: " + result.ToString("F2", CultureInfo.InvariantCulture));
                    for (int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());
                                                            
                }

               
            }

            // Traçando uma linha horizontal
            LinhaHorizontaEL();

            Console.WriteLine();
            ft.MargEsquRed();
            ft.MargEsquRed();
            ft.MargEsquRed();
            //Imprimindo o valor total da locação
            Console.Write("Valor total = R$ ");
            Console.WriteLine(soma.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();
            ft.MargEsqu();
            Console.Write("Digite uma opção do menu: ");
        }
    }
}
