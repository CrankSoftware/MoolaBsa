using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class AccountConductInput : BaseModelInput
    {
        public AccountConductInput()
        {
            FilterType = FilterType.FilterIn;
            FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
