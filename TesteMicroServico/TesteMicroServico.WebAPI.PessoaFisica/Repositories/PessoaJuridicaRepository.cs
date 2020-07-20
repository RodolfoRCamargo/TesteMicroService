using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMicroServico.WebAPI.PessoaFisica.Data;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Services
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        #region Propriedades
        private readonly ApplicationDbContext _context;
        #endregion

        #region Construtor
        public PessoaJuridicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<IEnumerable<PessoaJuridica>> ConsultarTodasPessoaJuridica()
        {
            var pessoas = await _context.PessoaJuridica.ToListAsync();

            return pessoas;
        }

        public async Task<ActionResult<PessoaJuridica>> IncluirUmaPessoaJuridica(string nome)
        {
            var pessoa = new PessoaJuridica()
            {
                Nome = nome
            };

            _context.PessoaJuridica.Add(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<ActionResult<PessoaJuridica>> AlterarUmaPessoaJuridica(Guid id, string nome)
        {
            PessoaJuridica pessoa = _context.PessoaJuridica.Find(id);
            pessoa.Nome = nome;
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<ActionResult<PessoaJuridica>> ExcluirUmaPessoaJuridica(Guid id)
        {
            PessoaJuridica pessoa = _context.PessoaJuridica.Find(id);
            _context.PessoaJuridica.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }
        #endregion
    }
}
