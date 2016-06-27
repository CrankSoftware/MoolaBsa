using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class GamblingInput : BaseInput
    {
        public GamblingInput()
        {
            this.FilterType = FilterType.FilterIn;
            this.FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
