using Moola.Bsa.Logic.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Moola.Bsa.Logic.Enumerations;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using Moola.Bsa.Logic.Models.Inputs;

namespace Moola.Bsa.Logic.Models
{
    public class AccountConductModel : BaseModel
    {
        public override  string ModelName { get; protected set; }
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

        public override IEnumerable<IModelOutput> Process(IModelInput input)
        {
            var result = new List<IModelOutput>();
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
                throw new BsaInputParameterException("The FilterPolarity value for this model must be Nagative"); ;
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
                    if (record.Description.ToLowerInvariant().Contains(term.ToLowerInvariant()))
                    {
                        if (matchedRecords.ContainsKey(term))
                        {
                            matchedRecords[term].Add(record);
                        }
                        else
                        {
                            matchedRecords.Add(term,new List<IRecord>() {record});
                        }
                        break;
                    }
                }
            }

            //var summary
            //Output result 1

            //Output result 2

            return result;
        }
    }
}
