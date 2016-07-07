using System;
using System.Collections.Generic;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Abstract;

namespace Moola.Bsa.Logic.Models.Outputs
{
    public class AccountConductOverallSummary: BaseModelOutput, IMostRecentDate, IDateRangeInDays
    {

        public List<AccountConductGroupSummary> AccountConductGroupSummaries { get; set; }

        public int DateRangeInDays { get; set; }

        public DateTime MostRecentDate { get; set; }
        public double MostRecentAmount { get; set; }
        public double DailyCount { get; set; }
        public double DailySum { get; set; }
    }
}
