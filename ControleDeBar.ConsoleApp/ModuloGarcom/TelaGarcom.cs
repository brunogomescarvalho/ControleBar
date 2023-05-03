using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            this.repositorioBase = repositorioGarcom;
            this.nomeEntidade = "Garçom";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            if (registros.Count > 0)
            {
                string cabecalho = "Selecionar Garçom\n\nID  | NOME\n-------------------";
                MostrarLista(registros, cabecalho);
            }

        }

        protected override Garcom ObterRegistro()
        {
            Console.WriteLine("Informe o nome:");
            string nome = Console.ReadLine()!;

            return new Garcom(nome);

        }


    }
}
