using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Linq;

namespace Locadora_Ary.Navegacao
{
    class AcervoLocado
    {
        public void ListaAcervoLoc()
        {
            //Declarando as classes 'Acervo' e 'Formatação'
            Acervo ac = new Acervo();
            Formatacao ft = new Formatacao();

            // Acessando o arquivo de texto: 'Acervo', cujo 
            //endereçco 'caminho' está na classe 'Acervo'
            StreamReader sr = File.OpenText(ac.Caminho());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter()+"  \t\tAcervo Locado");
            int conta3 = (ft.Caracter()+"  \t\tAcervo Locado").Count();
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
            Console.Write(ft.Caracter()+ "  Código  /   Título  /   Cod Cli /   Cliente   /  Data locação");
            int conta5 = (ft.Caracter()+ "  Código  /   Título  /   Cod Cli /   Cliente   /  Data locação").Count();
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
                int codigocli = int.Parse(line[2]);
                string cliente = line[3];
                string data = line[4];

                //Se o campo 'cliente' não estiver vazio, o filme está locado 
                if (cliente != "")
                {
                    // Para códigos de um digito
                    if (codigo < 10)
                    {
                        int conta=(ft.Caracter()+" " +codigo + " . . ." + titulo + "/ "+codigocli + "/ " + cliente + "/ " + data).Count();
                        int conta2 = ac.CountMaxCaract() - conta-2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter()+" " + codigo + " . . ." + titulo + "/ " + codigocli + "/ " + cliente + "/ " + data);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(ft.Caracter());
                    }
                    // Para códigos de dois digitos
                    if (codigo >= 10)
                    {
                        int conta = (ft.Caracter()+" " + codigo + " . . " + titulo + "/ " + codigocli + "/ " + cliente + "/ " + data).Count();
                        int conta2 = ac.CountMaxCaract() - conta-2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter()+" " + codigo + " . . " + titulo + "/ " + codigocli + "/ " + cliente + "/ " + data);
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

            ft.MargEsqu();
            Console.WriteLine();
            ft.MargEsqu();
            Console.Write("Digite uma opção do menu: ");

        }
    }
}
