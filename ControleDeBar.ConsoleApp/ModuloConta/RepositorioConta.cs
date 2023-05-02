using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList registros)
        {
            this.listaRegistros = registros;
        }

        public override Conta SelecionarPorId(int id)
        {
            return(Conta) base.SelecionarPorId(id);
        }
    }
}
