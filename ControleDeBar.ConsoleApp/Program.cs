using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());

            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta,telaGarcom, telaMesa, telaProduto);

            AdicionarItens(repositorioProduto, repositorioMesa, repositorioGarcom);

            TelaBase tela;
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("====== Bar Da Galera ======\n");

                    string opcao1 = "1 - Módulo Garçom";
                    string opcao2 = "2 - Módulo Mesa";
                    string opcao3 = "3 - Módulo Produto";
                    string opcao4 = "4 - Módulo Conta";
                    string voltar = "9 - Voltar";

                    Console.Write($"{opcao1}\n{opcao2}\n{opcao3}\n{opcao4}\n{voltar}\n=> ");
                    int opcao = int.Parse(Console.ReadLine()!);

                    switch (opcao)
                    {
                        case 1: tela = telaGarcom; break;
                        case 2: tela = telaMesa; break;
                        case 3: tela = telaProduto; break;
                        case 4: tela = telaConta; break;
                        case 9: continuar = false;continue;
                        default: continue;
                    }

                    string subMenu = "";

                    if (tela is TelaConta)
                    {
                        do
                        {
                            subMenu = tela.ApresentarMenu();

                            switch (subMenu)
                            {
                                case "1": telaConta.InserirNovoRegistro(); break;
                                case "2": telaConta.ExibirContasCadastradas(); break;
                                case "3": telaConta.ExibirContasEmAberto(); break;
                                case "4": telaConta.ExibirDetalhesConta(); break;
                                case "5": telaConta.IncluirPedido(); break;
                                case "6": telaConta.ExcluirPedido(); break;
                                case "7": telaConta.Finalizar(); break;
                                case "8": telaConta.ExibirFaturamentoDiario(); break;

                            }
                        } while (subMenu != "s");
                    }

                    do
                    {
                        subMenu = tela.ApresentarMenu();

                        switch (subMenu)
                        {
                            case "1": tela.InserirNovoRegistro(); break;
                            case "2": tela.VisualizarRegistros(true); Console.ReadKey(); break;
                            case "3": tela.EditarRegistro(); break;
                            case "4": tela.ExcluirRegistro(); break;

                            default: continue;
                        }
                    }
                    while (subMenu != "s");


                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida");
                    Console.ReadLine();
                }

            }

        }

        private static void AdicionarItens(RepositorioProduto repositorioProduto, RepositorioMesa repositorioMesa, RepositorioGarcom repositorioGarcom)
        {
            repositorioGarcom.Inserir(new Garcom("Alfredo"));
            repositorioGarcom.Inserir(new Garcom("Antenor"));

            repositorioProduto.Inserir(new Produto("Coca-Cola", "Lata 350ml", 4.50M));
            repositorioProduto.Inserir(new Produto("Aipim Frito", "Porção 500g", 14.00M));
            repositorioProduto.Inserir(new Produto("Torresminho", "Porção 500g", 12.00M));
            repositorioProduto.Inserir(new Produto("Cerveja Skol", "Garrafa 600ml", 8.0M));

            repositorioMesa.Inserir(new Mesa(4));
            repositorioMesa.Inserir(new Mesa(6));
            repositorioMesa.Inserir(new Mesa(8));
        }
    }
}