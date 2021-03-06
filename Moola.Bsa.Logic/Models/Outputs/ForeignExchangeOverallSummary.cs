﻿using System;
using System.Collections.Generic;
using Moola.Bsa.Logic.Abstract;
using Moola.Bsa.Logic.Interfaces.Configuration;

namespace Moola.Bsa.Logic.Models.Outputs
{
    public class ForeignExchangeOverallSummary : BaseModelOutput, IMostRecentDate, IDateRangeInDays
    {

        public List<ForeignExchangeGroupSummary> ForeignExchangeGroupSummaries { get; set; }

        public int DateRangeInDays { get; set; }

        public DateTime MostRecentDate { get; set; }
        public double MostRecentAmount { get; set; }
        public double DailyCount { get; set; }
        public double DailySum { get; set; }
    }
}
