using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class FinanceDepositsInput : BaseModelInput
    {
        public FinanceDepositsInput()
        {
            FilterType = FilterType.FilterIn;
            //Note: this is different to all other inputs other than Income
            FilterPolarity = FilterPolarity.PositiveValues;
        }
    }
}
