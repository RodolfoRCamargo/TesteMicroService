﻿using TesteMicroServico.WebAPI.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Models
{
    public class TransacaoPessoaJuridica : Transacao
    {        
        public double Tarifa
        {
            get { return Valor / 100 * 2; }
        }

        public double Liquido
        {
            get { return Valor - Tarifa; }
        }
    }
}
