using Microsoft.EntityFrameworkCore;
using TesteMicroServico.WebAPI.PessoaFisica.Models;

namespace TesteMicroServico.WebAPI.PessoaFisica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TesteMicroServico.WebAPI.PessoaFisica.Models.Pessoa> PessoaFisica { get; set; }
        public DbSet<TesteMicroServico.WebAPI.PessoaFisica.Models.TransacaoPessoaFisica> TransacaoPessoaFisica { get; set; }
        public DbSet<TesteMicroServico.WebAPI.PessoaFisica.Models.TransacaoPessoaJuridica> TransacaoPessoaJuridica { get; set; }
        public DbSet<TesteMicroServico.WebAPI.PessoaFisica.Models.PessoaJuridica> PessoaJuridica { get; set; }
    }
}
