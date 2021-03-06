﻿using System;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.Enumerations;
using Moola.Bsa.Logic.ExtensionMethods;
using System.Linq;
using System.Collections.Generic;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Models.Outputs;

namespace Moola.Bsa.Logic.Models
{
    public class FinanceWithdrawalsModel : BaseModel
    {
        private static IModel _instance;
        public static IModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FinanceWithdrawalsModel();
                }
                return _instance ?? new FinanceWithdrawalsModel();
            }
        }

        public FinanceWithdrawalsModel()
        {
            ModelName = "FinanceWithdrawalsModel";
        }

        public override IModelOutput Analyze(IModelInput input)
        {
            var financeWithdrawalsInput = input as FinanceWithdrawalsInput;
            if (financeWithdrawalsInput == null)
            {
                throw new BsaInputParameterException("The parameter FinanceWithdrawalsInput cannot be null.");
            }

            var dateRangeInDays = financeWithdrawalsInput.DateRangeInDays;
            if (dateRangeInDays == 0)
            {
                throw new BsaInputParameterException("The DateRangeInDays value cannot be 0 or less than 0.");
            }

            if (financeWithdrawalsInput.FilterType != FilterType.FilterIn)
            {
                throw new BsaInputParameterException("The FilterType value must be FilterIn");
            }

            if (financeWithdrawalsInput.FilterPolarity != FilterPolarity.NegativeValues)
            {
                throw new BsaInputParameterException("The FilterPolarity value for this model must be Nagative");
            }

            if (input.BankRecords == null)
            {
                throw new BsaInputParameterException("The BankRecords value cannot be null");
            }

            if (!input.BankRecords.Records.AnySave())
            {
                throw new BsaInputParameterException("The records value cannot be null or empty");
            }

            var leastDateTime = DateTime.UtcNow.AddDays(-dateRangeInDays);

            var recordsFilteredByDate =
                financeWithdrawalsInput.BankRecords.Records.Where(record => DateTime.Compare(record.TransactionDate, leastDateTime) >= 0 && record.Amount < 0)
                                   .OrderBy(record => record.Description);

            IDictionary<string, IList<IRecord>> matchedRecords;
            if (!GetMatchedRecords(recordsFilteredByDate, financeWithdrawalsInput, out matchedRecords))
            {
                return null;
            }

            //var summary
            //Output result 1
            var groupSummaries = new List<FinanceWithdrawalsGroupSummary>();
            foreach (var keyValuePair in matchedRecords)
            {
                var groupSummary = new FinanceWithdrawalsGroupSummary();
                groupSummary.Records = keyValuePair.Value.ToList();
                groupSummary.DistinctDescription = keyValuePair.Key;
                groupSummary.Count = keyValuePair.Value.Count;
                groupSummary.Sum = keyValuePair.Value.Sum(record => record.Amount);
                groupSummaries.Add(groupSummary);
            }

            //Output result 2
            var allMatchedRecords = matchedRecords.Values.SelectMany(keyValue => keyValue).Where(value => value != null)
                                        .OrderByDescending(record => record.TransactionDate);

            var overallSum = allMatchedRecords.Sum(record => record.Amount);
            var overallCount = allMatchedRecords.Count();
            var modeRecentRecord = allMatchedRecords.FirstOrDefault();
            if (modeRecentRecord == null)
            {
                return null;
            }

            var overallSummary = new FinanceWithdrawalsOverallSummary();
            overallSummary.GamblingGroupSummaries = groupSummaries;
            overallSummary.DateRangeInDays = input.DateRangeInDays;
            overallSummary.MostRecentAmount = modeRecentRecord.Amount;
            overallSummary.MostRecentDate = modeRecentRecord.TransactionDate;
            overallSummary.DailySum = Math.Round(overallSum / input.DateRangeInDays, 4);
            overallSummary.DailyCount = Math.Round((double)overallCount / input.DateRangeInDays, 4);
            overallSummary.Sum = overallSum;
            overallSummary.Count = overallCount;
            overallSummary.Records = allMatchedRecords.ToList();
            return overallSummary;
        }
    }
}
