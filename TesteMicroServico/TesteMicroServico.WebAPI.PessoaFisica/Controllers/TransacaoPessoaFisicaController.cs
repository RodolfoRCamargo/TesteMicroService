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
    public class TransacaoPessoaFisicaController
    {
        #region Propriedades
        private readonly ApplicationDbContext _context;
        #endregion
        private readonly IEmailSender _enviarEmail;

        #region Construtor
        public TransacaoPessoaFisicaController(IEmailSender enviarEmail, ApplicationDbContext context)
        {
            _enviarEmail = enviarEmail;
            _context = context;
        }        
        #endregion

        #region Método
        [HttpGet]
        public IEnumerable<TransacaoPessoaFisica> Get(string tipoTransacao)
        {
            return _context.TransacaoPessoaFisica
                .Where(t => t.TipoTransacao == tipoTransacao);
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoPessoaFisica>> Post(TransacaoPessoaFisica transacao)
        {
            var pessoa = _context.PessoaFisica.Find(transacao.Pessoa.Id);
            
            transacao.Pessoa = pessoa;
            _context.TransacaoPessoaFisica.Add(transacao);
            await _context.SaveChangesAsync();

            await _enviarEmail.SendEmailAsync(null, "Teste de Envio de Email", $"Transação de {transacao.TipoTransacao} no valor {transacao.Valor.ToString("c")} para Pessoa Física.");

            return transacao;
        }
        #endregion    
    }
}
