﻿using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Enumerations;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public class ForeignExchangeInput : BaseModelInput
    {
        public ForeignExchangeInput()
        {
            this.FilterType = FilterType.FilterIn;
            this.FilterPolarity = FilterPolarity.NegativeValues;
        }
    }
}
