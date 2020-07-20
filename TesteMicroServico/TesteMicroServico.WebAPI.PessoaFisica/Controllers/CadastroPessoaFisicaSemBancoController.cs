using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Services;

namespace TesteMicroServico.WebAPI.PessoaFisica.Models
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroPessoaFisicaSemBancoController
    {
        #region Métodos
        [HttpGet]
        public IEnumerable<Pessoa> ListarTodasPessoasFisica()
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            listaPessoas.Add(new Pessoa()
            {
                Id = Guid.NewGuid(),
                Nome = "Pessoa de Teste"
            });            

            return listaPessoas;
        }

        [HttpPost]
        public ActionResult<Pessoa> Post(Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();
            var resultado = pessoa;

            return resultado;
        }

        [HttpPut]
        public ActionResult<Pessoa> Put(Pessoa pessoa)
        {
            var resultado = pessoa;

            return resultado;
        }

        [HttpDelete]
        public ActionResult<Pessoa> Delete(Guid id)
        {
            var resultado = new Pessoa()
            {
                Id = id,
                Nome = "Pessoa Física Excluída"
            };

            return resultado;
        }
        #endregion
    }
}
