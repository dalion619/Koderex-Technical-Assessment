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
        public USD_VendingServiceTests() => _vendingService = new VendingService(
            currencyConfig: new CurrencyConfigService(coinDenominations: CurrencyCoinDenominationConstants.USD));

        private readonly IVendingService _vendingService;

        [Fact]
        public void ThrowsExWithInvalidChangeAmount()
        {
            Assert.Throws<Exception>(
                testCode: () => _vendingService.CalculateChange(purchaseAmount: 2, tenderAmount: 1));
        }

        [Fact]
        public void ThrowsExWithInvalidPurchaseAmount()
        {
            Assert.Throws<Exception>(
                testCode: () => _vendingService.CalculateChange(purchaseAmount: 0, tenderAmount: 1));
        }

        [Fact]
        public void ThrowsExWithInvalidTenderAmount()
        {
            Assert.Throws<Exception>(
                testCode: () => _vendingService.CalculateChange(purchaseAmount: 1, tenderAmount: 0));
        }

        [Fact]
        public void ValidCoinsForChange()
        {
            var coins = _vendingService.CalculateChange(purchaseAmount: 1.35m, tenderAmount: 2);
            var changeAmount = coins.Sum();
            Assert.NotEmpty(collection: coins);
            Assert.Equal(expected: 65, actual: changeAmount);
            Assert.Equal(expected: 4, actual: coins.Count);
        }

        [Fact]
        public void ValidNoChangeNoCoins()
        {
            var coins = _vendingService.CalculateChange(purchaseAmount: 1, tenderAmount: 1);
            Assert.Empty(collection: coins);
        }
    }
}