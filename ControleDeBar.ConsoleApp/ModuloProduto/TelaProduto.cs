using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            this.nomeEntidade = "Produto";
            this.sufixo = "s";
            this.repositorioBase = repositorioProduto;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Produto item in registros)
            {
                Console.WriteLine($"{item.id} - {item.nome} - {item.descricao} - {item.preco}");
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine($"Informe o nome do {nomeEntidade}:");
            string nome = Console.ReadLine()!;

            Console.WriteLine("Informe a descrição:");
            string descricao = Console.ReadLine()!;

            Console.WriteLine("Informe o preço:");
            decimal preco = decimal.Parse(Console.ReadLine()!);

          return new Produto(nome, descricao, preco);

        }
    }
}
