using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Services
{
    public interface IPessoaFisicaRepository
    {
        public Task<IEnumerable<Pessoa>> ConsultarTodasPessoaFisica();
        public Task<ActionResult<Pessoa>> IncluirUmaPessoaFisica(string nome);
        public Task<ActionResult<Pessoa>> AlterarUmaPessoaFisica(Guid id, string nome);
        public Task<ActionResult<Pessoa>> ExcluirUmaPessoaFisica(Guid id);
    }
}
