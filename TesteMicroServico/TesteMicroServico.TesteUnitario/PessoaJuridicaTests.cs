using TesteMicroServico.WebAPI.PessoaFisica.Models;
using Xunit;

namespace TesteMicroServico.TesteDeUnidade
{
    public class PessoaJuridicaTests
    {
        [Trait("Teste de Unidade", "Pessoa Jurídica - Cadastro")]
        [Theory(DisplayName = "Cobrar Tarifa de 5% no Débito")]
        [InlineData(100, 5, 95)]
        [InlineData(15, 0.75, 14.25)]
        [InlineData(55, 2.75, 52.25)]
        [InlineData(1000, 50, 950)]
        [InlineData(103, 5.15, 97.85)]
        public void CobrarTarifaDebitoPessoaJuridica(double valor, double tarifa, double liquido)
        {
            TransacaoPessoaJuridica transacao =
                new TransacaoPessoaJuridica()
                { Valor = valor };

            Assert.Equal(valor - tarifa, liquido);
        }
    }
}
