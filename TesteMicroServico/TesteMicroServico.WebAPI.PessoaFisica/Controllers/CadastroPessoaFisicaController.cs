using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Services;

namespace TesteMicroServico.WebAPI.PessoaFisica.Models
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroPessoaFisicaController
    {
        #region Propriedades
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        #endregion

        #region Construtor
        public CadastroPessoaFisicaController(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }
        #endregion

        #region Métodos
        [HttpGet]
        public async Task<IEnumerable<Pessoa>> ListarTodasPessoasFisica()
        {
            var pessoas = await _pessoaFisicaRepository.ConsultarTodasPessoaFisica();

            return pessoas;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post(Pessoa pessoa)
        {
            var resultado = await _pessoaFisicaRepository.IncluirUmaPessoaFisica(pessoa.Nome);

            return resultado;
        }

        [HttpPut]
        public async Task<ActionResult<Pessoa>> Put(Pessoa pessoa)
        {
            var resultado = await _pessoaFisicaRepository.AlterarUmaPessoaFisica(pessoa.Id, pessoa.Nome);

            return resultado;
        }

        [HttpDelete]
        public async Task<ActionResult<Pessoa>> Delete(Guid id)
        {
            var resultado = await _pessoaFisicaRepository.ExcluirUmaPessoaFisica(id);

            return resultado;
        }
        #endregion
    }
}
