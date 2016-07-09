using Moola.Bsa.Logic.Enumerations;
using System.Collections.Generic;

namespace Moola.Bsa.Logic.Interfaces.Input
{
    public interface IModelInput
    {
        /// <summary>
        /// The number of days that the records span
        /// </summary>
        /// <remarks>This is not the difference between the min and max transaction dates in Records</remarks>
        /// <example>90 days is likely to be the value</example>
        int DateRangeInDays { get; set; }

        /// <summary>
        /// Bank account records for input
        /// </summary>
        IRecords BankRecords { get; set; }

        /// <summary>
        /// The terms by which to filter the records
        /// </summary>
        List<string> FilterTerms { get; set; }

        /// <summary>
        /// If the filter terms are filtering in or out
        /// </summary>
        FilterType FilterType { get;}

        /// <summary>
        /// The polarity of the records to include by this term (negative or positive)
        /// </summary>
        FilterPolarity FilterPolarity { get;}
    }
}
