using Koderex.TechnicalAssessment.VendingMachine.Utilities;
using Xunit;

namespace UnitTests
{
    public class CurrencyCoinDenominationTests
    {
        [Fact]
        public void CurrencyCoinDenominationsNotNullOrEmpty()
        {
            var gbp = CurrencyCoinDenominationConstants.GBP;
            var usd = CurrencyCoinDenominationConstants.USD;

            Assert.NotNull(gbp);
            Assert.NotNull(usd);

            Assert.NotEmpty(gbp);
            Assert.NotEmpty(usd);
        }
    }
}