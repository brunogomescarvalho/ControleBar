using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;


namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private readonly TelaGarcom telaGarcom;
        private readonly TelaMesa telaMesa;
        private readonly TelaProduto telaProduto;
        private readonly RepositorioConta repositorioConta;

        public TelaConta(RepositorioConta repositorioConta, TelaGarcom telaGarcom, TelaMesa telaMesa, TelaProduto telaProduto)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioConta = repositorioConta;
            this.telaProduto = telaProduto;
            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
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
            Console.WriteLine($"Digite 4 para Visualizar Detalhes da Conta");
            Console.WriteLine($"Digite 5 para Adicionar pedido");
            Console.WriteLine($"Digite 6 para Remover pedido");
            Console.WriteLine($"Digite 7 para Finalizar conta");
            Console.WriteLine($"Digite 8 para Visualizar Total Faturado no Dia");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine()!;

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            if (registros.Count > 0)
            {
                MostrarCabecalhoConta();
                foreach (var item in registros)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void ExibirContasEmAberto()
        {
            MostrarTexto("=== Exibindo contas em aberto ===");
            MostrarContasEmAberto();

            if (repositorioBase.SelecionarTodos().Count == 0)
                return;

            Console.ReadKey();
        }

        public void ExibirContasCadastradas()
        {
            Console.Clear();
            VisualizarRegistros(false);

            if (repositorioBase.SelecionarTodos().Count > 0)
                Console.ReadKey();
        }

        public void Finalizar()
        {
            MostrarTexto("== Finalizar Conta == \n");
            MostrarContasEmAberto();

            if (repositorioBase.SelecionarTodos().Count == 0)
                return;

            Conta conta = (Conta)EncontrarRegistro("Informe o id da conta para finalizar:\n=>");

            if (conta.Aberta == false)
            {
                MostrarMensagem("Conta já finalizada", ConsoleColor.DarkYellow);
                return;
            }

            conta.FinalizarConta();

            MostrarMensagem("Conta finalizada com sucesso", ConsoleColor.Green);
        }

        protected override EntidadeBase ObterRegistro()
        {
          telaMesa.VisualizarRegistros(false);

            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("\nInforme o id da mesa:\n=> ");

            if (mesa.Disponivel == false)
            {
                MostrarMensagem("Mesa já ocupada, por favor escolha outra", ConsoleColor.DarkYellow);
                Console.Clear();
                ObterRegistro();
            }

            Console.Clear();
            telaGarcom.VisualizarRegistros(false);

            Garcom garcom = (Garcom)telaGarcom.EncontrarRegistro("\nDigite o id do garçom:\n=> ");
            return new Conta(mesa, garcom);

        }

        public void IncluirPedido()
        {
            MostrarTexto("== Incluir Pedido ==\n");
            MostrarContasEmAberto();

            if (repositorioBase.SelecionarTodos().Count == 0)
                return;

            Conta conta = (Conta)EncontrarRegistro("\nInforme o id da conta:\n=> ");

            if (conta.Aberta == false)
            {
                MostrarMensagem("Conta já finalizada", ConsoleColor.DarkYellow);
                return;
            }

            Console.Clear();
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("\nDigite o id do produto:\n=> ");

            MostrarTexto("Informe a quantidade");
            int quantidade = int.Parse(Console.ReadLine()!);

            conta.AdicionarPedido(quantidade, produto);

            MostrarMensagem("Pedido incluido com sucesso", ConsoleColor.Green);

        }

        public void ExcluirPedido()
        {
            MostrarTexto("== Excluir pedido ==\n");
            MostrarContasEmAberto();

            if (repositorioBase.SelecionarTodos().Count == 0)
                return;

            Conta conta = (Conta)EncontrarRegistro("\nInforme o id da conta\n=> ");

            if(conta.Aberta == false)
            {
                MostrarMensagem("Conta já finalizada", ConsoleColor.DarkYellow);
                return;
            }

            Console.Clear();
            MostrarItensConta(conta, false);

            Console.Write("\nInforme o id do pedido para excluir\n=> ");
            int id = int.Parse(Console.ReadLine()!);

            foreach (Pedido item in conta.Pedidos)
            {
                if (item.Id == id)
                {
                    conta.Pedidos.Remove(item);
                    MostrarMensagem("Item removido", ConsoleColor.DarkGreen);
                    return;
                }
            }

            MostrarMensagem("Pedido não localizado", ConsoleColor.DarkYellow);
           
        }


        public void ExibirDetalhesConta()
        {
            MostrarTexto("== Detalhes da Conta ==\n");
            VisualizarRegistros(false);

            if (repositorioBase.SelecionarTodos().Count == 0)
                return;

            Conta conta = (Conta)EncontrarRegistro("Informe o id da conta para ver detalhes:\n=> ");

            Console.Clear();

            MostrarItensConta(conta, true);
        }

        private void MostrarItensConta(Conta conta, bool esperarTecla)
        {
            if (conta.Pedidos.Count == 0)
            {
                MostrarMensagem("Nenhum pedido até o momento!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine(MostrarCabecalhoPedidos());

            foreach (var item in conta.Pedidos)
            {
                Console.WriteLine(item);
            }

            if(esperarTecla)
                Console.ReadKey();

        }



        public void ExibirFaturamentoDiario()
        {
            MostrarCabecalho("Faturamento diario", "Digite a data que deseja faturar (dd/MM/yyyy)...");

            try
            {
                DateTime data = Convert.ToDateTime(Console.ReadLine()!);

                decimal valor = repositorioConta.CalcularFaturamentoDoDia(data);

                if (valor == 0)
                {
                    MostrarMensagem($"Nenhum valor faturado no dia {data:d}", ConsoleColor.DarkYellow);
                    return;
                }
                MostrarMensagem($"O faturamento no dia {data:d} foi de R$ {valor}", ConsoleColor.White);
            }
            catch (FormatException)
            {
                MostrarMensagem("Data informada em um formato inválido", ConsoleColor.Red);
            }
        }

        private void MostrarContasEmAberto()
        {
            ArrayList contasEmAberto = repositorioConta.MostrarContasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhum registro em aberto até o momento!", ConsoleColor.DarkYellow);
            }

            MostrarTabela(contasEmAberto);
        }

       

        private void MostrarCabecalhoConta()
        {
            Console.WriteLine($"{"ID",-3} | {"MESA",-5} | {"GARÇOM",-10} | {"STATUS",-10} | {"VALOR",-18} | {"DATA-HORA"}");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        private string MostrarCabecalhoPedidos()
        {
            return $"{"ID",-3} | {"Produto",-18} | {"Descricao",-18} | {"Qtd",-5} | {"Total item",-10}";
        }
    }
}
