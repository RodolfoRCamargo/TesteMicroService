using System;

namespace TesteMicroServico.WebAPI.PessoaFisica.Services
{
    public class EmailSettings
    {
        public bool EnviarEmail { get; set; }
        public String PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public String UsernameEmail { get; set; }
        public String UsernamePassword { get; set; }
        public String FromEmail { get; set; }
        public String ToEmail { get; set; }
    }
}
