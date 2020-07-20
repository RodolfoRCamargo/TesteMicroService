using TesteMicroServico.WebAPI.PessoaFisica.Models;
using Xunit;

namespace TesteMicroServico.TesteDeUnidade
{
    public class PessoaFisicaTest
    {
        [Trait("Teste de Unidade", "Pessoa Física - Cadastro")]
        [Theory(DisplayName = "Cobrar Tarifa de 2% no Débito")]
        [InlineData(100, 2, 98)]
        [InlineData(15, 0.30, 14.70)]
        [InlineData(55, 1.10, 53.90)]
        [InlineData(1000, 20, 980)]
        [InlineData(103, 2.06, 100.94)]
        public void CobrarTarifaDebitoPessoaFisica(double valor, double tarifa, double liquido)
        {
            TransacaoPessoaFisica transacao =
                new TransacaoPessoaFisica()
                { Valor = valor };

            Assert.Equal(valor - tarifa, liquido);
        }
    }
}
