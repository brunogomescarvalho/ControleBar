using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using Microsoft.Win32;
using System;
using System.Collections;


namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private readonly RepositorioGarcom repositorioGarcom;
        private readonly RepositorioMesa repositorioMesa;
        private readonly RepositorioProduto repositorioProduto;
        public TelaConta(RepositorioConta repositorioConta, RepositorioGarcom repositorioGarcom, RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioMesa = repositorioMesa;
            this.repositorioProduto = repositorioProduto;
            this.nomeEntidade = "conta";
            this.sufixo = "s";
        }
        public override string ApresentarMenu()
        {

            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Abrir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar Todas as {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Visualizar {nomeEntidade}{sufixo}  Em Aberto");
            Console.WriteLine($"Digite 4 para Adicionar pedidos");
            Console.WriteLine($"Digite 5 para Finalizar conta");
            Console.WriteLine($"Digite 6 Visualizar Total Faturado no Dia");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Conta item in registros)
            {
                Console.WriteLine($"{item.id} - {item.mesa.id} - {(item.aberta ? "Aberta" : "Finalizada")} - {item.valorTotal}");
                Console.WriteLine("\nItens pedido\n");
                foreach (Pedido pedido in item.pedidos)
                {
                    Console.WriteLine($"{pedido.produto.nome} - {pedido.quantidade}");
                }
            }


        }

        public void MostrarPedidosEmAberto()
        {
            
            foreach (Conta item in repositorioBase.SelecionarTodos())
            {
                if (item.aberta == true)
                {
                    Console.WriteLine($"{item.id} - {item.mesa.id} - {(item.aberta ? "Aberta" : "Finalizada")} - {item.valorTotal}");
                    Console.WriteLine("\nItens pedido\n");
                    foreach (Pedido pedido in item.pedidos)
                    {
                        Console.WriteLine($"{pedido.produto.nome} - {pedido.quantidade}");
                    }

                }

            }

        }

        public void Finalizar()
        {
            Console.Clear();
            Console.WriteLine("id Conta -- id Mesa -- ValorTotal");
            foreach (Conta item in repositorioBase.SelecionarTodos())
            {
                if (item.aberta == true)
                    Console.WriteLine($"{item.id} - {item.mesa.id} - {item.valorTotal}");
            }

            Console.WriteLine("\nInforme o id da conta para incluir um pedido:");
            int id = int.Parse(Console.ReadLine()!);

            Conta conta = (Conta)repositorioBase.SelecionarPorId(id);

            conta.FinalizarConta();


        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Clear();
            Console.WriteLine("id Garçom -- Nome");
            foreach (Garcom item in repositorioGarcom.SelecionarTodos())
            {
                Console.WriteLine($"{item.id} - {item.nome}");
            }

            Console.WriteLine("Selecione o id do garçom");
            int id = int.Parse(Console.ReadLine()!);
            Garcom garcom = repositorioGarcom.SelecionarPorId(id);

            foreach (Mesa item in repositorioMesa.SelecionarTodos())
            {
                if (item.disponivel == true)
                    Console.WriteLine($"{item.id} - {item.CapacidadeDePessoas}");
            }

            Console.Clear();
            Console.WriteLine("id Mesa -- Capacidade pessoas");
            Console.WriteLine("Selecione a mesa");
            int idMesa = int.Parse(Console.ReadLine()!);

            Mesa mesa = repositorioMesa.SelecionarPorId(idMesa);

            return new Conta(mesa, garcom);

        }

        public void IncluirPedido()
        {
            try
            {
                foreach (Conta item in repositorioBase.SelecionarTodos())
                {
                    if (item.aberta == true)
                        Console.WriteLine($"{item.id} - {item.mesa.id} - {item.valorTotal}");
                }

                Console.WriteLine("\nInforme o id da conta para incluir um pedido:");
                int id = int.Parse(Console.ReadLine()!);

                Conta conta = (Conta)repositorioBase.SelecionarPorId(id);

                foreach (Produto item in repositorioProduto.SelecionarTodos())
                {
                    Console.WriteLine($"{item.id} - {item.nome} - {item.descricao} - R$ {item.preco}");
                }

                Console.WriteLine("\nInforme o id da produto para incluir no pedido:");
                int idProduto = int.Parse(Console.ReadLine()!);

                Produto produto = repositorioProduto.SelecionarPorId(idProduto);

                Console.WriteLine("Informe a quantidade");
                int quantidade = int.Parse(Console.ReadLine()!);

                conta.AdicionarPedido(quantidade, produto);
               conta.
            }
            catch (NullReferenceException)
            {
                MostrarMensagem("Ocorreu um erro ao tentar adicionar o pedido", ConsoleColor.Red);
                IncluirPedido();
            }

            MostrarMensagem("Pedido incluido com sucesso", ConsoleColor.Green);

        }
    }
}
