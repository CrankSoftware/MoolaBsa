using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class IncomeInput : BaseModelInput
    {
        public IncomeInput()
        {
            //Note: these are both different to all other inputs other than Finance Deposits
            FilterType = FilterType.FilterOut;
            FilterPolarity = FilterPolarity.PositiveValues;
        }
    }
}
