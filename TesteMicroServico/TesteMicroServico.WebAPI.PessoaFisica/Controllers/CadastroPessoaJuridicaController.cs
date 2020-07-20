using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Data;
using TesteMicroServico.WebAPI.PessoaFisica.Models;
using TesteMicroServico.WebAPI.PessoaFisica.Services;

namespace TesteMicroServico.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroPessoaJuridicaController : Controller
    {
        #region Propriedades
        private readonly ApplicationDbContext _context;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        #endregion

        #region Construtor
        public CadastroPessoaJuridicaController(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }
        #endregion

        [HttpGet]
        public async Task<IEnumerable<PessoaJuridica>> ListarTodasPessoasFisica()
        {
            var pessoas = await _pessoaJuridicaRepository.ConsultarTodasPessoaJuridica();

            return pessoas;
        }

        [HttpPost]
        public async Task<ActionResult<PessoaJuridica>> Post(PessoaJuridica pessoa)
        {
            var resultado = await _pessoaJuridicaRepository.IncluirUmaPessoaJuridica(pessoa.Nome);

            return resultado;
        }

        [HttpPut]
        public async Task<ActionResult<PessoaJuridica>> Put(PessoaJuridica pessoa)
        {
            var resultado = await _pessoaJuridicaRepository.AlterarUmaPessoaJuridica(pessoa.Id, pessoa.Nome);

            return resultado;
        }

        [HttpDelete]
        public async Task<ActionResult<PessoaJuridica>> Delete(Guid id)
        {
            var resultado = await _pessoaJuridicaRepository.ExcluirUmaPessoaJuridica(id);

            return resultado;
        }
    }
}
