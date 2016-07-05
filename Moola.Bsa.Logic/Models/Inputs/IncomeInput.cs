using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class IncomeInput : BaseInput
    {
        public IncomeInput()
        {
            //Note: these are both different to all other inputs other than Finance Deposits
            this.FilterType = FilterType.FilterOut;
            this.FilterPolarity = FilterPolarity.PositiveValues;
        }
    }
}
