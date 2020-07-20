using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Data;
using TesteMicroServico.WebAPI.PessoaFisica.Models;
using TesteMicroServico.WebAPI.PessoaFisica.Services;

namespace TesteMicroServico.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoPessoaJuridicaController : Controller
    {
        #region Propriedades
        private readonly ApplicationDbContext _context;
        #endregion
        private readonly IEmailSender _enviarEmail;

        #region Construtor
        public TransacaoPessoaJuridicaController(IEmailSender enviarEmail, ApplicationDbContext context)
        {
            _enviarEmail = enviarEmail;
            _context = context;
        }
        #endregion

        #region Método
        [HttpGet]
        public IEnumerable<TransacaoPessoaJuridica> Get(string tipoTransacao)
        {
            return _context.TransacaoPessoaJuridica
                .Where(t => t.TipoTransacao == tipoTransacao);
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoPessoaJuridica>> Post(TransacaoPessoaJuridica transacao)
        {
            var pessoa = _context.PessoaFisica.Find(transacao.Pessoa.Id);

            transacao.Pessoa = pessoa;
            _context.TransacaoPessoaJuridica.Add(transacao);
            await _context.SaveChangesAsync();

            await _enviarEmail.SendEmailAsync(null, "Teste de Envio de Email", $"Transação de {transacao.TipoTransacao} no valor {transacao.Valor.ToString("c")} para Pessoa Jurídica.");

            return transacao;
        }
        #endregion 
    }
}
