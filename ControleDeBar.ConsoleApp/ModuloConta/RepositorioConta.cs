using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

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

        public decimal CalcularFaturamentoDoDia(DateTime data)
        {
            decimal valor = 0;
            foreach (Conta item in listaRegistros)
            {
                if (item.DataConta.Date == data)
                {
                    foreach (Pedido pedido in item.Pedidos)
                    {
                        valor += pedido.CalcularValorPedido();
                    }
                }
            }

            return valor;
        }

        public ArrayList MostrarContasEmAberto()
        {
            ArrayList registros = listaRegistros;

            ArrayList contasEmAberto = new();

            foreach (Conta item in registros)
            {
                if (item.Aberta == true)
                {
                    contasEmAberto.Add(item);
                }
            }

            return contasEmAberto;
        }
    }
}
