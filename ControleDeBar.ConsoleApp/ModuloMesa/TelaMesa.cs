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
            foreach (Mesa item in registros)
            {
                Console.WriteLine($"{item.id} - {(item.disponivel ? "Disponível":"Ocupada")}");
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
