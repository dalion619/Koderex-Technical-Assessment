using System.Linq;
using Koderex.TechnicalAssessment.VendingMachine.Interfaces;
using Koderex.TechnicalAssessment.VendingMachine.Services;
using Koderex.TechnicalAssessment.VendingMachine.Utilities;
using Xunit;

namespace UnitTests
{
    public class GBP_VendingServiceTests
    {
        private readonly IVendingService _vendingService;
        public GBP_VendingServiceTests()
        {
            _vendingService = new VendingService(new CurrencyConfigService(CurrencyCoinDenominationConstants.GBP));
        }
        
        [Fact]
        public void ValidCoinsForChange()
        {
            var coins = _vendingService.CalculateChange(1.35m, 2);
            var changeAmount = coins.Sum();
            Assert.NotEmpty(coins);
            Assert.Equal(65, changeAmount);
            Assert.Equal(3, coins.Count);
        }
    }
}