using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {

        public string nome { get; private set; }
        public string descricao { get; private set; }
        public decimal preco { get; private set; }

        public Produto(string nome, string descricao, decimal preco)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produto = (Produto)registroAtualizado;
            nome = produto.nome;
            descricao = produto.descricao;
            preco = produto.preco;
        }

        public override ArrayList Validar()
        {
            ArrayList lista = new ArrayList();
            if (preco <= 0)
            {
                lista.Add("Preço informado é inválido.");
            }
            if (descricao.Trim() == string.Empty || descricao.Trim().Length == 0)
            {
                lista.Add("Descrião campo é obrigatório");
            }
            if (nome.Trim() == string.Empty || nome.Trim().Length == 0)
            {
                lista.Add("Nome campo é obrigatório");
            }
            return lista;
        }
    }
}

