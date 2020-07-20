using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TransacaoPessoaJuridicaTests
    {
        #region Propriedades
        private readonly IntegrationTestsFixture<StartupTestes> _testsFixture;
        #endregion

        #region Construtor
        public TransacaoPessoaJuridicaTests(IntegrationTestsFixture<StartupTestes> testsFixture)
        {
            _testsFixture = testsFixture;
        }
        #endregion

        #region Métodos
        [Fact(DisplayName = "Realizar Transação de Débito Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Transação")]
        public async Task RealizarTransacaoDebitoPessoaJuridica() 
        {
            // Arrange
            var pessoa = await ObterPessoa();

            var transacao = new TransacaoPessoaJuridica()
            {
                Pessoa = pessoa,
                TipoTransacao = "Débito",
                Valor = 500
            };

            var transacaoInString = JsonConvert.SerializeObject(transacao);

            // Act
            var postRequest = await _testsFixture.Client.PostAsync("transacaoPessoaJuridica", new StringContent(transacaoInString, Encoding.UTF8, "application/json"));

            // Assert
            postRequest.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Realizar Transação de Crédito Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Transação")]
        public async Task RealizarTransacaoCreditoPessoaJuridica() 
        {
            // Arrange
            var pessoa = await ObterPessoa();

            var transacao = new TransacaoPessoaJuridica()
            {
                Pessoa = pessoa,
                TipoTransacao = "Crédito",
                Valor = 1000
            };

            var transacaoInString = JsonConvert.SerializeObject(transacao);

            // Act
            var postRequest = await _testsFixture.Client.PostAsync("transacaoPessoaJuridica", new StringContent(transacaoInString, Encoding.UTF8, "application/json"));

            // Assert
            postRequest.EnsureSuccessStatusCode();
        }

        private async Task<Pessoa> ObterPessoa() 
        {
            var getPessoa = await _testsFixture.Client.GetAsync($"cadastroPessoaJuridica");
            var pessoas = JsonConvert.DeserializeObject<Pessoa[]>(await getPessoa.Content.ReadAsStringAsync());

            Pessoa pessoa = null;
            if (pessoas.Count() > 0)
            {
                pessoa = pessoas[0];
            }
            else
            {
                pessoa = new Pessoa()
                {
                    Nome = $"Nova Pessoa Física {DateTime.Now}"
                };

                var pessoaJsonString = JsonConvert.SerializeObject(pessoa);
                var pessoaTeste = await _testsFixture.Client.PostAsync("cadastroPessoaJuridica", new StringContent(pessoaJsonString, Encoding.UTF8, "application/json"));
                pessoa = JsonConvert.DeserializeObject<Pessoa>(await pessoaTeste.Content.ReadAsStringAsync());
            }

            return pessoa;
        }

        [Fact(DisplayName = "Listar Transações de Débito Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Transação")]
        public async Task ListarTransacoesDebitoPessoaJuridica() 
        {
            // Arrange
            var transacao = new TransacaoPessoaFisica()
            {
                TipoTransacao = "Débito"
            };

            // Act
            var getRequest = await _testsFixture.Client.GetAsync($"transacaoPessoaJuridica?tipoTransacao={transacao.TipoTransacao}");

            // Assert
            getRequest.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Listar Transações de Crédito Pessoa Jurídica")]
        [Trait("Teste de Integração", "Pessoa Jurídica - Transação")]
        public async Task ListarTransacoesCreditoPessoaJuridica() 
        {
            // Arrange
            var transacao = new TransacaoPessoaFisica()
            {
                TipoTransacao = "Crédito"
            };

            // Act
            var getRequest = await _testsFixture.Client.GetAsync($"transacaoPessoaJuridica?tipoTransacao={transacao.TipoTransacao}");

            // Assert
            getRequest.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
