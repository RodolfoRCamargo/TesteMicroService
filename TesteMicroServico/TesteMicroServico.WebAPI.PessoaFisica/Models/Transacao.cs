using System;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public string TipoTransacao { get; set; }
        public double Valor { get; set; }
    }
}
