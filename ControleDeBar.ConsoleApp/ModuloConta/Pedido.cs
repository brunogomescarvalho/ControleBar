using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido
    {
        public Produto produto { get; set; }
        public int quantidade { get; set; }
        public Pedido(Produto produto, int quantidade)
        {
            this.produto = produto;
            this.quantidade = quantidade;
        }

       public decimal CalcularValorParcial()
        {
            return quantidade * produto.preco;
        }





      


    }
}
