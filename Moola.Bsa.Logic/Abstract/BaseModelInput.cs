using System.Collections.Generic;
using Moola.Bsa.Logic.Enumerations;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Interfaces.Input;

namespace Moola.Bsa.Logic.Abstract
{
    public abstract class BaseModelInput:IModelInput
    {

        public int DateRangeInDays { get; set; }

        public List<IRecord> Records { get; set; }

        public List<string> FilterTerms { get; set; }

        public FilterType FilterType { get; protected set; }

        public FilterPolarity FilterPolarity { get; protected set; }
    }
}
