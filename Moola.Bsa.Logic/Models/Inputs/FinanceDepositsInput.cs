using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class FinanceDepositsInput : BaseInput
    {
        public FinanceDepositsInput()
        {
            this.FilterType = FilterType.FilterIn;
            //Note: this is different to all other inputs other than Income
            this.FilterPolarity = FilterPolarity.PositiveValues;
        }
    }
}
