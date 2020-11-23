using System;
using System.IO;
using System.Security;
using Locadora_Ary.Navegacao;
using Locadora_Ary.Acoes;
using Locadora_Ary.Entrada;
using System.Globalization;
using System.Net.Http.Headers;

namespace Locadora_Ary
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Declarando todas as classes que serão utilizadas
                Login lg = new Login();
                Acervo ac = new Acervo();
                AcervoDisponível acd = new AcervoDisponível();
                AcervoLocado acl = new AcervoLocado();
                AcervoProcura acp = new AcervoProcura();
                Clientes cli = new Clientes();
                Devolucao devol = new Devolucao();
                Locacao lc = new Locacao();
                Formatacao ft = new Formatacao();
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                ClienteProcura clipr = new ClienteProcura();

                //formatação cor de fundo e das letras
                Console.Title = "Sistema de Locacao";//titulo do console
                Console.BackgroundColor = ConsoleColor.DarkCyan;//cor de fundo
                Console.ForegroundColor = ConsoleColor.White;//cor das letras
                Console.Clear();

                ft.Altura();
                ft.MargEsqu();
                Console.WriteLine("Locadora Total Video");
                Console.WriteLine();

                //Login do funcionário e primeiro acesso ao menu da locadora
                ft.Linha();
                Console.WriteLine();
                ft.MargEsquRed();
                ft.MargEsquRed();
                Console.Write("Prezado colaborador, digite seu username: ");
                string username = Console.ReadLine().ToLower();// todas as letras do username vão para minusculas
                Console.WriteLine();
                ft.MargEsquRed();
                ft.MargEsquRed();
                Console.Write("Agora digite sua senha numerica: ");
                int senha = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Clear();
                if (lg.VerificaUsuario(username, senha) == true)
                {

                    // Menu da locadora
                    ft.Altura();
                    ft.MargEsqu();
                    Console.WriteLine("Locadora Total Video");
                    Console.WriteLine();
                    Console.Write("\t\t\t\t\tOlá " + ti.ToTitleCase(username));// a primeira letra do usename vai para maiuscula
                    Console.WriteLine(", digite uma opçao do menu:\n");
                    ft.Linha();
                    Console.WriteLine("\n 1 Acervo Completo │ 2 Acervo disponível │ 3 Acervo Locado │ 4 Procurar filme │ 5 Locar │ 6 Devolução │ 7 lista de clientes │ 8 Procurar cliente | 9 sair");
                    ft.Linha();
                    Console.WriteLine();
                    ft.MargEsqu();
                    Console.Write("Digite sua opção aqui: ");
                }
                else
                {
                    ft.Altura();
                    ft.MargEsqu();
                    Console.WriteLine("Atenção! Username e/ou senha incorreto");
                }

                // Menu da locadora repetido
                int n = 0;
                //Loop enquanto 'n' for diferente do inteiro '9'
                while (n != 9)
                {
                    n = int.Parse(Console.ReadLine());

                    Console.Clear();
                    ft.Altura();
                    ft.MargEsqu();
                    Console.WriteLine("Locadora Total Video");
                    Console.WriteLine();
                    Console.Write("\t\t\t\t\tOlá " + ti.ToTitleCase(username));
                    Console.WriteLine(", digite uma opçao do menu:\n");
                    ft.Linha();
                    Console.WriteLine("\n 1 Acervo Completo │ 2 Acervo disponível │ 3 Acervo Locado │ 4 Procurar filme │ 5 Locar │ 6 Devolução │ 7 lista de clientes │ 8 Procurar cliente | 9 sair");
                    ft.Linha();
                    Console.WriteLine();
                   
                    switch (n)
                    {
                        case 1:
                            ac.ListaAcervo();
                            break;
                        case 2:
                            acd.ListaAcervoDisp();
                            break;
                        case 3:
                            acl.ListaAcervoLoc();
                            break;
                        case 4:
                            ft.MargEsqu();
                            Console.WriteLine("\t\tProcura de Filmes");
                            Console.Write("\t\t\t\t\t");
                            Console.Write("Digite um termo de busca (SEM ACENTOS, nome ou parte do nome do filme): ");
                            acp.Nome = Console.ReadLine().ToLower();
                            acp.Procura(acp.Nome);
                            break;
                        case 5:
                            ft.MargEsqu();
                            Console.WriteLine("Locação de Filmes");
                            ft.MargEsqu();
                            Console.Write("Digite o código do filme desejado: ");
                            lc.CodigoFilm = int.Parse(Console.ReadLine());
                            ft.MargEsqu();
                            Console.Write("Digite o código do Cliente: ");
                            lc.CodigoCli = int.Parse(Console.ReadLine());
                            lc.DataLoca = DateTime.Now;
                            lc.Locar(lc.CodigoCli, lc.CodigoFilm, lc.DataLoca);
                            break;

                        case 6:
                            ft.MargEsqu();
                            Console.WriteLine("Devolução de Filmes");
                            ft.MargEsqu();
                            Console.Write("Digite o código do cliente: ");
                            devol.CodigoCli = int.Parse(Console.ReadLine());
                            devol.DataDevol = DateTime.Now;
                            devol.Calculo(devol.CodigoCli, devol.DataDevol, devol.CodigoFilm);
                            break;
                        case 7:
                            cli.ListaClientes();
                            break;
                        case 8:
                            ft.MargEsqu();
                            Console.WriteLine("\t\tProcura de Clientes");
                            Console.Write("\t\t\t\t\t");
                            Console.Write("Digite um termo de busca (SEM ACENTOS, nome ou parte do nome do cliente): ");
                            clipr.Nome = Console.ReadLine().ToLower();
                            clipr.ProcuraCli(clipr.Nome);
                            break;
                    }



                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro!");
                Console.WriteLine(e.Message);
            }
            

        }

    }
}
