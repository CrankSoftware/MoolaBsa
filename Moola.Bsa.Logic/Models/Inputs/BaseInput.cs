using System.Collections.Generic;
using Moola.Bsa.Logic.Enumerations;
using Moola.Bsa.Logic.Interfaces;

namespace Moola.Bsa.Logic.Models.Inputs
{
    public abstract class BaseInput : IRecords
    {
        /// <summary>
        /// The number of days that the records span
        /// </summary>
        /// <remarks>This is not the difference between the min and max transaction dates in Records</remarks>
        /// <example>90 days is likely to be the value</example>
        public int DateRangeInDays { get; set; }

        /// <summary>
        /// Bank account records for input
        /// </summary>
        public List<Record> Records { get; set; }

        /// <summary>
        /// The terms by which to filter the records
        /// </summary>
        public List<string> FilterTerms { get; set; }

        /// <summary>
        /// If the filter terms are filtering in or out
        /// </summary>
        public FilterType FilterType { get; protected set; }

        /// <summary>
        /// The polarity of the records to include by this term (negative or positive)
        /// </summary>
        public FilterPolarity FilterPolarity { get; protected set; }
    }
}
