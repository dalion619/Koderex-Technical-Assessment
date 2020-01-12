using System.Collections.Generic;

namespace Koderex.TechnicalAssessment.VendingMachine.Interfaces
{
    public interface IVendingService
    {
        List<int> CalculateChange(decimal purchaseAmount, decimal tenderAmount);
    }
}