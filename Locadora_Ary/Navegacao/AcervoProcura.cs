using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Globalization;

namespace Locadora_Ary.Navegacao
{
    class AcervoProcura
    {
        
        public string Nome { get; set; }

        public AcervoProcura()
        {
        }

        public AcervoProcura(string nome)
        {
            Nome = nome;

        }

        public void Procura(string nome)
        {
            //Declarando as classes 'Acervo' e 'Formatação'
            Acervo ac = new Acervo();
            Formatacao ft = new Formatacao();

            // Acessando o arquivo de texto: 'Acervo', cujo 
            //endereçco 'caminho' está na classe 'Acervo'
            StreamReader sr = File.OpenText(ac.Caminho());

            //Criando o acabeçalho
            Console.WriteLine();
            ft.MargEsqu();
            Console.WriteLine("\t\tResultado da busca:");
            ft.MargEsquRed();
            Console.WriteLine("\t(Atenção: código do cliente vazio e data = 01/01/0001 significa que o filme não está locado)");
            Console.WriteLine();
            
            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter() + "  \t\tTitulo encontrado");
            int conta3 = (ft.Caracter() + "  \t\tTitulo encontrado").Count();
            int conta4 = ac.CountMaxCaract() - conta3 - 13;
            for (int i = 1; i < conta4; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho inferior e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter() + "  Código  /   Título  /   Cliente   /  Data locação");
            int conta5 = (ft.Caracter() + "  Código  /   Título  /   Cliente   /  Data locação").Count();
            int conta6 = ac.CountMaxCaract() - conta5 - 2;
            for (int i = 1; i < conta6; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            while (!sr.EndOfStream)
            {
                //Lendo e selecionando os dados do arquivo 'Acervo'
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string titulo = line[1];
                string cliente = line[3];
                string data = line[4];

                //Selecionando o termo de busca
                if (titulo.Contains(nome))
                {
                    // Para códigos de filme com um digito
                    if (codigo < 10)
                    {
                        int conta = (ft.Caracter() + " " + codigo + " . . ." + titulo + "/ " + "/ " + cliente + "/ " + data).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter() + " " + codigo + " . . ." + titulo + "/ " + "/ " + cliente + "/ " + data);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(ft.Caracter());
                    }
                    // Para códigos de filme com dois digitos
                    if (codigo >= 10)
                    {
                        int conta = (ft.Caracter() + " " + codigo + " . . " + titulo + "/ " + "/ " + cliente + "/ " + data).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter() + " " + codigo + " . . " + titulo + "/ " + "/ " + cliente + "/ " + data);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(ft.Caracter());
                    }
                }

            }

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            Console.WriteLine();
            ft.MargEsqu();
            Console.WriteLine("Fim da pesquisa");
            Console.WriteLine();
            ft.MargEsqu();
            Console.Write("Digite uma opção do menu: ");



        }

    }
}
