using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class GamblingInput : BaseModelInput
    {
        public GamblingInput()
        {
            FilterType = FilterType.FilterIn;
            FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
