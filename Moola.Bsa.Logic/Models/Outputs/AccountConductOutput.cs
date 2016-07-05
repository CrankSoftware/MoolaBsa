using System;
using System.Collections.Generic;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Models.Inputs;

namespace Moola.Bsa.Logic.Models.Outputs
{
    public class AccountConductOutput: IMostRecentDate, IDateRangeInDays, ISum, ICount
    {
        /// <summary>
        /// Output 1
        /// </summary>
        public List<AccountConductGroupSummary> AccountConductGroupSummaries { get; set; }

        /// <summary>
        /// Output 2
        /// </summary>
        public int Count { get; set; }

        public int DateRangeInDays { get; set; }

        public DateTime MostRecentDate { get; set; }

        public double Sum { get; set; }

        /// <summary>
        /// The matching records
        /// </summary>
        public List<IRecord> Records { get; set; }
    }
}
