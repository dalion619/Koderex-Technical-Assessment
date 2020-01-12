using System;
using System.Collections.Generic;
using Koderex.TechnicalAssessment.VendingMachine.Interfaces;

namespace Koderex.TechnicalAssessment.VendingMachine.Services
{
    public class VendingService : IVendingService
    {
        private readonly ICurrencyConfigService _currencyConfig;

        public VendingService(ICurrencyConfigService currencyConfig)
        {
            _currencyConfig = currencyConfig;
        }


        public List<int> CalculateChange(decimal purchaseAmount, decimal tenderAmount)
        {
            var coinDenominations = _currencyConfig.GetCoinDenominations();
            var coins = new List<int>();
            if (purchaseAmount <= 0)
            {
                throw new Exception($"{nameof(purchaseAmount)} value is zero or less.");
            }

            if (tenderAmount <= 0)
            {
                throw new Exception($"{nameof(tenderAmount)} value is zero or less.");
            }

            var changeAmount = tenderAmount - purchaseAmount;
            if (changeAmount == 0)
            {
                return coins;
            }

            if (changeAmount < 0)
            {
                throw new Exception($"{nameof(changeAmount)} value is negative.");
            }

            var nonFloatingChangeAmount = changeAmount * 100;
            for (int c = 0; c < coinDenominations.Length; c++)
            {
                var coin = coinDenominations[c];
                while(nonFloatingChangeAmount >= coin)
                {
                    coins.Add(coin);
                    nonFloatingChangeAmount -= coin;
                }

                if (nonFloatingChangeAmount == 0)
                {
                    break;
                }
            }
            

            return coins;
        }
    }
}