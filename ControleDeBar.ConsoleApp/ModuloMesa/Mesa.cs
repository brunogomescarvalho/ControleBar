using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int CapacidadeDePessoas { get; set; }

        public bool disponivel { get; set; }
        public Mesa(int capacidadeDePessoas)
        {
            this.disponivel = true;
            CapacidadeDePessoas = capacidadeDePessoas;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
