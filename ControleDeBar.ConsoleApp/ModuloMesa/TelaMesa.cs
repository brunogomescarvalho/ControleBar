using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            this.nomeEntidade = "mesa";
            this.sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            if (registros.Count > 0)
            {
                string cabecalho = $"{"ID",-3} | {"Capacidade",-12} | {"STATUS",-20}\n----------------------------------";

                MostrarLista(registros, cabecalho);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Informe a capacidade de pessoas da mesa");
            int capacidade = int.Parse(Console.ReadLine()!);

            return new Mesa(capacidade);
        }
    }
}
