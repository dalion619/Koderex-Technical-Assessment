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

            Assert.NotNull(@object: gbp);
            Assert.NotNull(@object: usd);

            Assert.NotEmpty(collection: gbp);
            Assert.NotEmpty(collection: usd);
        }
    }
}