using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Models;
using TesteMicroServico.WebAPI.PessoaFisica.Data;
using TesteMicroServico.WebAPI.PessoaFisica.Services;

namespace TesteMicroServico.WebAPI.PessoaFisica.Models
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoPessoaFisicaSemBancoController
    {
        #region Método
        [HttpGet]
        public IEnumerable<TransacaoPessoaFisica> Get(string tipoTransacao)
        {
            List<TransacaoPessoaFisica> listaPessoas = new List<TransacaoPessoaFisica>();
            listaPessoas.Add(new TransacaoPessoaFisica()
            {
                Id = Guid.NewGuid(),
                Pessoa = new Pessoa()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pessoa Física"
                },
                TipoTransacao = "Débito",
                Valor = 300
            });

            return listaPessoas;
        }

        [HttpPost]
        public ActionResult<TransacaoPessoaFisica> Post(TransacaoPessoaFisica transacao)
        {
            return new TransacaoPessoaFisica()
            {
                Id = Guid.NewGuid(),
                Pessoa = new Pessoa()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pessoa Física"
                },
                TipoTransacao = "Débito",
                Valor = 300
            };
        }
        #endregion    
    }
}
