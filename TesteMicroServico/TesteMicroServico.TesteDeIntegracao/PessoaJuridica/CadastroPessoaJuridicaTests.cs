using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteMicroServico.TesteDeIntegracao.Config;
using TesteMicroServico.WebAPI.PessoaFisica;
using TesteMicroServico.WebAPI.PessoaFisica.Models;
using Xunit;

namespace TesteMicroServico.TesteDeIntegracao.PessoaJuridica
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class CadastroPessoaJuridicaTests
    {
        #region Propriedades
        private readonly IntegrationTestsFixture<StartupTestes> _testsFixture;
        #endregion

        #region Construtor
        public CadastroPessoaJuridicaTests(IntegrationTestsFixture<StartupTestes> testsFixture)
        {
            _testsFixture = testsFixture;
        }
        #endregion

        #region Métodos
        [Fact(DisplayName = "Listar Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task ListarPessoaJuridica() 
        {
            // Act
            var getResponse = await _testsFixture.Client.GetAsync($"cadastroPessoaJuridica");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Incluir Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task IncluirPessoaJuridica() 
        {
            // Arrange
            var pessoa = new Pessoa()
            {
                Nome = $"Nova Pessoa Física {DateTime.Now}"
            };

            var pessoaInString = JsonConvert.SerializeObject(pessoa);

            // Act
            var postRequest = await _testsFixture.Client.PostAsync("cadastroPessoaJuridica", new StringContent(pessoaInString, Encoding.UTF8, "application/json"));

            // Assert
            postRequest.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Alterar Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task AlterarPessoaJuridica() 
        {
            // Arrange
            var pessoa = new Pessoa()
            {
                Nome = $"Alterar Pessoa Física {DateTime.Now}"
            };

            var pessoaJsonString = JsonConvert.SerializeObject(pessoa);

            // Act
            var postRequest = await _testsFixture.Client.PostAsync("cadastroPessoaJuridica", new StringContent(pessoaJsonString, Encoding.UTF8, "application/json"));
            var pessoaAlterar = JsonConvert.DeserializeObject<Pessoa>(await postRequest.Content.ReadAsStringAsync());

            pessoaAlterar.Nome = $"Pessoa Jurídica Alterada {DateTime.Now}";
            var pessoaAlterarJsonString = JsonConvert.SerializeObject(pessoaAlterar);
            var putRequest = await _testsFixture.Client.PutAsync("cadastroPessoaJuridica", new StringContent(pessoaAlterarJsonString, Encoding.UTF8, "application/json"));

            // Assert
            putRequest.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Impedir Alteração Pessoa Jurídica sem GUID")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task ImpedirAlteracaoPessoaJuridicaSemGuid()
        {
            try
            {
                // Arrange
                var pessoaAlterar = new Pessoa()
                {
                    Nome = $"Alterar Pessoa Jurídica {DateTime.Now}"
                };

                var pessoaJsonString = JsonConvert.SerializeObject(pessoaAlterar);

                // Act
                pessoaAlterar.Nome = $"Pessoa Jurídica Alterada {DateTime.Now}";
                var pessoaAlterarJsonString = JsonConvert.SerializeObject(pessoaAlterar);
                var putRequest = await _testsFixture.Client.PutAsync("cadastroPessoaJuridica", new StringContent(pessoaAlterarJsonString, Encoding.UTF8, "application/json"));

                // Assert
                Assert.True(false);
            }
            catch
            {
                // Assert
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Impedir Alteração Pessoa Jurídica com GUID incorreto")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task ImpedirAlteracaoPessoaJuridicaComGuidIncorreto() 
        {
            try
            {
                // Arrange
                var pessoaAlterar = new Pessoa()
                {
                    Id = Guid.NewGuid(),
                    Nome = $"Alterar Pessoa Jurídica {DateTime.Now}"
                };

                var pessoaJsonString = JsonConvert.SerializeObject(pessoaAlterar);

                // Act
                pessoaAlterar.Nome = $"Pessoa Jurídica Alterada {DateTime.Now}";
                var pessoaAlterarJsonString = JsonConvert.SerializeObject(pessoaAlterar);
                var putRequest = await _testsFixture.Client.PutAsync("cadastroPessoaJuridica", new StringContent(pessoaAlterarJsonString, Encoding.UTF8, "application/json"));

                // Assert
                Assert.True(false);
            }
            catch
            {
                // Assert
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Excluir uma Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Cadastro")]
        public async Task ExcluirPessoaJuridica() 
        {
            // Arrange
            var pessoa = new Pessoa()
            {
                Nome = $"Excluir Pessoa Jurídica {DateTime.Now}"
            };

            var pessoaJsonString = JsonConvert.SerializeObject(pessoa);

            // Act
            var postRequest = await _testsFixture.Client.PostAsync("cadastroPessoaJuridica", new StringContent(pessoaJsonString, Encoding.UTF8, "application/json"));
            var pessoaExcluir = JsonConvert.DeserializeObject<Pessoa>(await postRequest.Content.ReadAsStringAsync());

            var deleteRequest = await _testsFixture.Client.DeleteAsync($"cadastroPessoaJuridica?id={pessoaExcluir.Id}");

            // Assert
            deleteRequest.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
