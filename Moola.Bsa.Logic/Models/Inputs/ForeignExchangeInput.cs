using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class ForeignExchangeInput : BaseInput
    {
        public ForeignExchangeInput()
        {
            this.FilterType = FilterType.FilterIn;
            this.FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
