using System;
using System.IO;
using System.Linq;

namespace Locadora_Ary.Navegacao
{
    class Clientes
    {
        //Chamando as classes 'Acervo' e 'Formatação'
        Acervo ac = new Acervo();
        Formatacao ft = new Formatacao();

        
        public string CaminhoCli()
        {
            // Endereço do arquivo 'Clientes'
            return @"C:\Users\Administrador\source\repos\Locadora_Ary\Clientes.txt";
        }

        public void ListaClientes()
        {
            //Acessando o arquivo 'Clientes'
            string path = CaminhoCli();
            StreamReader sr = File.OpenText(path);

            // Contando o numero máximo de caracteres
            // a partir da função em acervo 
            ac.CountMaxCaract();

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter() + "  \t\tLista de Clientes");
            int conta3 = (ft.Caracter() + "  \t\tLista de Clientes").Count();
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
            Console.Write(ft.Caracter() + "  Código Cliente  " + ft.Caracter() + "  Cliente");
            int conta5 = (ft.Caracter() + "  Código do filme  " + ft.Caracter() + "  Título").Count();
            int conta6 = ac.CountMaxCaract() - conta5 - 2;
            for (int i = 1; i < conta6; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Coletando e imprimindo o conteúdo e traçando as linhas verticais
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string nome = line[1];
                
                // Para códigos de um digito
                if (codigo < 10)
                {
                    int conta = (ft.Caracter() + "\t" + codigo + " . . . . . ." + nome).Count();
                    int conta2 = ac.CountMaxCaract() - conta - 8;
                    ft.MargEsqu();
                    Console.Write(ft.Caracter() + "\t" + codigo + " . . . . . ." + nome);
                    for (int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());
                }
                // Para códigos de dois digitos
                if (codigo >= 10)
                {
                    int conta = (ft.Caracter() + "\t" + codigo + " . . . . . " + nome).Count();
                    int conta2 = ac.CountMaxCaract() - conta - 8;
                    ft.MargEsqu();
                    Console.Write(ft.Caracter() + "\t" + codigo + " . . . . . " + nome);
                    for (int i = 1; i < conta2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(ft.Caracter());
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
