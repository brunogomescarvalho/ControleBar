using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; private set; }

        public Garcom(string nome)
        {
            this.Nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcom = (Garcom)registroAtualizado;
            Nome = garcom.Nome;
        }

        public override ArrayList Validar()
        {
            ArrayList list = new ArrayList();

            if (this.Nome.Length < 3 || this.Nome.Trim() == string.Empty)
            {
                list.Add("Nome informado é inválido");
            }

            return list;
        }

        public override string ToString()
        {
            return $"{id,-3} | {Nome,-10}";
        }
    }
}
