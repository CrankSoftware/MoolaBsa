using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class AccountConductInput : BaseInput
    {
        public AccountConductInput()
        {
            this.FilterType = FilterType.FilterIn;
            this.FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
