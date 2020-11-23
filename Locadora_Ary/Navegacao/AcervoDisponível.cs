using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Locadora_Ary.Navegacao
{
    class AcervoDisponível
    {
        public void ListaAcervoDisp()
        {
            //Declarando as classes 'Acervo' e 'Formatação'
            Acervo ac = new Acervo();
            Formatacao ft = new Formatacao();

            // Acessando o arquivo de texto: Acervo, cujo 
            //endereçco 'caminho' está em acervo
            StreamReader sr = File.OpenText(ac.Caminho());

            // Contando o numero máximo de caracteres
            // a partir da função em acervo 
            ac.CountMaxCaract();

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter()+"  \t\tAcervo Disponível");
            int conta3 = (ft.Caracter()+"  \t\tAcervo Disponível").Count();
            int conta4 = ac.CountMaxCaract() - conta3 - 13;
            for (int i = 1; i < conta4; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Imprimindo o cabeçalho inferior
            ac.CabecaInferior();

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            while (!sr.EndOfStream)
            {
                //Lendo e selecionando os dados do arquivo 'Acervo'
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string titulo = line[1];
                string cliente = line[3];

                //Se o campo 'cliente' estiver vazio, o filme está disponível 
                if (cliente == "")
                {
                    //Imprimindo os filmes disponíveis
                    // Para códigos de um digito
                    if (codigo < 10)
                    {
                        int conta = (ft.Caracter()+"\t" + codigo + " . . ." + titulo).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 8;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter()+"\t" + codigo + " . . ." + titulo);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(ft.Caracter());
                    }
                    // Para códigos de dois digitos
                    if (codigo >= 10)
                    {
                        int conta = (ft.Caracter()+"\t" + codigo + " . . ." + titulo).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 8;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter()+"\t" + codigo + " . . " + titulo);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(" "+ ft.Caracter());
                    }
                }
                

            }

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            Console.WriteLine();
            ft.MargEsqu();
            Console.Write("Digite uma opção do menu: ");

        }

        

    }
}
