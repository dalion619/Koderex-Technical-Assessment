using System.Linq;
using Koderex.TechnicalAssessment.VendingMachine.Interfaces;
using Koderex.TechnicalAssessment.VendingMachine.Services;
using Koderex.TechnicalAssessment.VendingMachine.Utilities;
using Xunit;

namespace UnitTests
{
    public class GBP_VendingServiceTests
    {
        public GBP_VendingServiceTests() => _vendingService = new VendingService(
            currencyConfig: new CurrencyConfigService(coinDenominations: CurrencyCoinDenominationConstants.GBP));

        private readonly IVendingService _vendingService;

        [Fact]
        public void ValidCoinsForChange()
        {
            var coins = _vendingService.CalculateChange(purchaseAmount: 1.35m, tenderAmount: 2);
            var changeAmount = coins.Sum();
            Assert.NotEmpty(collection: coins);
            Assert.Equal(expected: 65, actual: changeAmount);
            Assert.Equal(expected: 3, actual: coins.Count);
        }
    }
}