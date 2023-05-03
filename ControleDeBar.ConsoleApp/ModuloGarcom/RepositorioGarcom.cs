using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public  class RepositorioGarcom : RepositorioBase
    {
        public RepositorioGarcom(ArrayList registros)
        {
            this.listaRegistros = registros;
        }

        public override Garcom SelecionarPorId(int id)
        {
            return (Garcom)base.SelecionarPorId(id);
        }
    }
}
