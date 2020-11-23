using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Locadora_Ary.Navegacao;

namespace Locadora_Ary.Entrada
{
    // Estabelecendo herança de 'AcervoProcura'
    class ClienteProcura : AcervoProcura
    {
        //Chamando as classes 'Acervo', 'Clientes' e 'Formatação'
        Acervo ac = new Acervo();
        Clientes cl = new Clientes();
        Formatacao ft = new Formatacao();

        public void ProcuraCli(string nome)
        {
            //Estabelecendo conexão com o arquivo 'Clientes.txt'
            StreamReader sr = File.OpenText(cl.CaminhoCli());

            //Criando o acabeçalho
            Console.WriteLine();
            ft.MargEsqu();
            Console.WriteLine("\t\tResultado da busca:");

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            //Centralizando o cabeçalho e colocando as linhas verticais
            ft.MargEsqu();
            Console.Write(ft.Caracter() + "  \t\tCliente encontrado");
            int conta3 = (ft.Caracter() + "  \t\tCliente encontrado").Count();
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
            Console.Write(ft.Caracter() + "  Código  /   Cliente   ");
            int conta5 = (ft.Caracter() + "  Código  /   Cliente   ").Count();
            int conta6 = ac.CountMaxCaract() - conta5 - 2;
            for (int i = 1; i < conta6; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(ft.Caracter());

            // Traçando uma linha horizontal
            ac.LinhaHorizontaL();

            // Corpo da tabela
            while (!sr.EndOfStream)
            {
                // lendo e armazenando os dados do arquivo 'Clientes'
                string[] line = sr.ReadLine().Split(',');
                int codigo = int.Parse(line[0]);
                string cliente = line[1];

                //Seleciona o termo de busca
                if (cliente.Contains(nome))
                {
                    //Para códigos de clientes com um digito
                    if (codigo < 10)
                    {
                        int conta = (ft.Caracter() + "   " + codigo + " . . ." + cliente).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter() + "   " + codigo + " . . ." + cliente);
                        for (int i = 1; i < conta2; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(ft.Caracter());
                    }
                    // Para códigos de clientes com dois digitos
                    if (codigo >= 10)
                    {
                        int conta = (ft.Caracter() + "   " + codigo + " . . " + cliente).Count();
                        int conta2 = ac.CountMaxCaract() - conta - 2;
                        ft.MargEsqu();
                        Console.Write(ft.Caracter() + "   " + codigo + " . . " + cliente);
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
