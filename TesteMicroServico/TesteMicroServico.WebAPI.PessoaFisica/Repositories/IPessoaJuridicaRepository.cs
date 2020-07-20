using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Services
{
    public interface IPessoaJuridicaRepository
    {
        public Task<IEnumerable<PessoaJuridica>> ConsultarTodasPessoaJuridica();
        public Task<ActionResult<PessoaJuridica>> IncluirUmaPessoaJuridica(string nome);
        public Task<ActionResult<PessoaJuridica>> AlterarUmaPessoaJuridica(Guid id, string nome);
        public Task<ActionResult<PessoaJuridica>> ExcluirUmaPessoaJuridica(Guid id);
    }
}
