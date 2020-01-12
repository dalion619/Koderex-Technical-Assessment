using Koderex.TechnicalAssessment.VendingMachine.Interfaces;

namespace Koderex.TechnicalAssessment.VendingMachine.Services
{
    public class CurrencyConfigService : ICurrencyConfigService
    {
        private readonly int[] _coinDenominations;

        public CurrencyConfigService(int[] coinDenominations) => _coinDenominations = coinDenominations;

        public int[] GetCoinDenominations() => _coinDenominations;
    }
}