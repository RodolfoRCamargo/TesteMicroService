using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Data;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Services
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        #region Propriedades
        private readonly ApplicationDbContext _context;
        #endregion

        #region Construtor
        public PessoaFisicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<IEnumerable<Pessoa>> ConsultarTodasPessoaFisica()
        {
            var pessoas = await _context.PessoaFisica.ToListAsync();

            return pessoas;
        }

        public async Task<ActionResult<Pessoa>> IncluirUmaPessoaFisica(string nome)
        {
            var pessoa = new Pessoa()
            {
                Nome = nome
            };

            _context.PessoaFisica.Add(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<ActionResult<Pessoa>> AlterarUmaPessoaFisica(Guid id, string nome)
        {
            Pessoa pessoa = _context.PessoaFisica.Find(id);
            pessoa.Nome = nome;
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<ActionResult<Pessoa>> ExcluirUmaPessoaFisica(Guid id)
        {
            Pessoa pessoa = _context.PessoaFisica.Find(id);
            _context.PessoaFisica.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }
        #endregion
    }
}
