using System;
using System.Collections.Generic;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Abstract;

namespace Moola.Bsa.Logic.Models.Outputs
{
    public class AccountConductOutput: BaseModelOutput, IMostRecentDate, IDateRangeInDays
    {
        /// <summary>
        /// Output 1
        /// </summary>
        public List<AccountConductGroupSummary> AccountConductGroupSummaries { get; set; }

        public int DateRangeInDays { get; set; }

        public DateTime MostRecentDate { get; set; }
    }
}
