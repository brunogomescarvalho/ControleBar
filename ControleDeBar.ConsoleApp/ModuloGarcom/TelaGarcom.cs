using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (Garcom item in registros)
            {
                Console.WriteLine($"{item.id} - {item.nome}");
            }
            Console.ReadKey();
        }

        protected override Garcom ObterRegistro()
        {
            Console.WriteLine("Informe o nome:");
            string nome = Console.ReadLine()!;

           return new Garcom(nome);
     
        }

       
    }
}
