using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {

        public string nome { get; private set; }

        public Garcom(string nome)
        {
            this.nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcom = (Garcom)registroAtualizado;
            nome = garcom.nome;
        }

        public override ArrayList Validar()
        {
            ArrayList list = new ArrayList();

            if (this.nome.Length < 3 || this.nome.Trim() == string.Empty)
            {
                list.Add("Nome informado é inválido");
            }

            return list;
        }
    }
}
