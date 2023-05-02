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
    public class Conta : EntidadeBase
    {

        public ArrayList pedidos { get; private set; }
        public Mesa mesa { get; private set; }
        public Garcom garcom { get; private set; }
        public bool aberta { get; private set; }
        public DateTime dataConta { get; private set; }

        public decimal valorTotal { get; private set; }
        public Conta(Mesa mesa, Garcom garcom)
        {
            this.pedidos = new ArrayList();
            this.mesa = mesa;
            this.garcom = garcom;
            this.aberta = true;
            this.dataConta = DateTime.Now;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            ArrayList list = new ArrayList();
            if (mesa == null || garcom == null)
                list.Add("Algo deu errado!");
            return list;
        }

        public void AdicionarPedido(int quantidade, Produto produto)
        {
            this.pedidos.Add(new Pedido(produto, quantidade));
        }

        public void FinalizarConta()
        {
            foreach (Pedido item in pedidos)
            {
                this.valorTotal += item.CalcularValorParcial();
            }
            this.aberta = false;
        }


    }
}
