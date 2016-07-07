using Moola.Bsa.Logic.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Moola.Bsa.Logic.Enumerations;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;

namespace Moola.Bsa.Logic.Models
{
    public class AccountConductModel : BaseModel
    {
        private static IModel _instance;
        public static IModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountConductModel();
                }
                return _instance ?? new AccountConductModel();
            }
        }

        public AccountConductModel()
        {
            ModelName = "AccountConductModel";
        }

        public override IModelOutput Analyze(IModelInput input)
        {
            var accountConductInput = input as AccountConductInput;
            if (accountConductInput == null)
            {
                throw new BsaInputParameterException("The parameter ModelInput cannot be null.");
            }

            var dateRangeInDays = accountConductInput.DateRangeInDays;
            if (dateRangeInDays == 0)
            {
                throw new BsaInputParameterException("The DateRangeInDays value cannot be 0 or less than 0.");
            }

            if (accountConductInput.FilterType != FilterType.FilterIn)
            {
                throw new BsaInputParameterException("The FilterType value must be FilterIn");
            }

            if (accountConductInput.FilterPolarity != FilterPolarity.NegativeValues)
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
                accountConductInput.BankRecords.Records.Where(record => DateTime.Compare(record.TransactionDate, leastDateTime) >= 0 && record.Amount<0)
                                   .OrderBy(record=>record.Description);
            
            var matchedRecords = new Dictionary<string,List<IRecord>>();
            foreach (var record in recordsFilteredByDate)
            {

                foreach (var term in accountConductInput.FilterTerms)
                {
                    var distinctMatchedDescription = GetMatchedDistinctDescription(record.Description, term);
                    record.DistinctDescription = distinctMatchedDescription;
                    if (!string.IsNullOrEmpty(distinctMatchedDescription))
                    {
                        if (matchedRecords.ContainsKey(distinctMatchedDescription))
                        {
                            matchedRecords[distinctMatchedDescription].Add(record);
                        }
                        else
                        {
                            matchedRecords.Add(distinctMatchedDescription, new List<IRecord>() {record});
                        }
                        break;
                    }
                }
            }

            if (!matchedRecords.Any())
            {
                return null;
            }
            //var summary
            //Output result 1
            var groupSummaries = new List<AccountConductGroupSummary>();
            foreach (var keyValuePair in matchedRecords)
            {
                var groupSummary = new AccountConductGroupSummary();
                groupSummary.Records = keyValuePair.Value;
                groupSummary.DistinctDescription = keyValuePair.Key;
                groupSummary.Count = keyValuePair.Value.Count;
                groupSummary.Sum = keyValuePair.Value.Sum(record => record.Amount);
                groupSummaries.Add(groupSummary);
            }

            //Output result 2
            var allMatchedRecords = matchedRecords.Values.SelectMany(keyValue => keyValue).Where(value=>value!=null)
                                        .OrderByDescending(record=>record.TransactionDate);

            var overallSum = allMatchedRecords.Sum(record => record.Amount);
            var overallCount = allMatchedRecords.Count();
            var modeRecentRecord = allMatchedRecords.FirstOrDefault();
            if (modeRecentRecord == null)
            {
                return null;
            }
            var overallSummary = new AccountConductOverallSummary();
            overallSummary.AccountConductGroupSummaries = groupSummaries;
            overallSummary.DateRangeInDays = input.DateRangeInDays;
            overallSummary.MostRecentAmount = modeRecentRecord.Amount;
            overallSummary.MostRecentDate = modeRecentRecord.TransactionDate;
            overallSummary.DailySum = Math.Round(overallSum / input.DateRangeInDays,4);
            overallSummary.DailyCount = Math.Round((double)overallCount / input.DateRangeInDays,4);
            overallSummary.Sum = overallSum;
            overallSummary.Count = overallCount;
            overallSummary.Records = allMatchedRecords.ToList();
            return overallSummary;
        }
    }
}
 