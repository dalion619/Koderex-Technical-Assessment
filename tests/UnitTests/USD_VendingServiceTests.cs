using System;
using System.Linq;
using Koderex.TechnicalAssessment.VendingMachine.Interfaces;
using Koderex.TechnicalAssessment.VendingMachine.Services;
using Koderex.TechnicalAssessment.VendingMachine.Utilities;
using Xunit;

namespace UnitTests
{
    public class USD_VendingServiceTests
    {
        private readonly IVendingService _vendingService;
        public USD_VendingServiceTests()
        {
            _vendingService = new VendingService(new CurrencyConfigService(CurrencyCoinDenominationConstants.USD));
        }
        
        [Fact]
        public void ThrowsExWithInvalidPurchaseAmount()
        {
            Assert.Throws<Exception>(() => _vendingService.CalculateChange(0, 1));
        }
        
        [Fact]
        public void ThrowsExWithInvalidTenderAmount()
        {
            Assert.Throws<Exception>(() => _vendingService.CalculateChange(1, 0));
        }
        
        [Fact]
        public void ThrowsExWithInvalidChangeAmount()
        {
            Assert.Throws<Exception>(() => _vendingService.CalculateChange(2, 1));
        }
        
        [Fact]
        public void ValidNoChangeNoCoins()
        {
            var coins = _vendingService.CalculateChange(1, 1);
            Assert.Empty(coins);
        }
        
        [Fact]
        public void ValidCoinsForChange()
        {
            var coins = _vendingService.CalculateChange(1.35m, 2);
            var changeAmount = coins.Sum();
            Assert.Equal(0.65m, changeAmount); 
        }
    }
}