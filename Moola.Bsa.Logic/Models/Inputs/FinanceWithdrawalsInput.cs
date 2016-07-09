using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class FinanceWithdrawalsInput : BaseModelInput
    {
        public FinanceWithdrawalsInput()
        {
            FilterType = FilterType.FilterIn;
            FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
