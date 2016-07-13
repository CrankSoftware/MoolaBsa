using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using Moola.Bsa.Logic.Interfaces;
using System.Collections.Generic;
using Moola.Bsa.Logic.ExtensionMethods;

namespace Moola.Bsa.Logic.Models
{
    public abstract class BaseModel : IModel
    {
        public string ModelName { get; protected set; }

        public abstract IModelOutput Analyze(IModelInput input);

        protected virtual string GetMatchedDistinctDescription(string description, string searchTerm)
        {

            if (string.IsNullOrEmpty(searchTerm))
            {
                return description;
            }

            var matchedWord = Regex.Match(description, @"\b" + searchTerm + @"(\b|[_a-zA-Z0-9]+\b)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            return matchedWord.Success == false? string.Empty: 
                                                 description.Substring(0, description.ToLowerInvariant().IndexOf(matchedWord.Value.ToLowerInvariant(), 
                                                 StringComparison.InvariantCulture)+ matchedWord.Length);
        }

        protected virtual bool GetMatchedRecords
        (
            IOrderedEnumerable<IRecord> recordsFilteredByDate, 
            IModelInput modelInput,
            out IDictionary<string, IList<IRecord>> matchedRecords
        )
        {
            matchedRecords = new Dictionary<string, IList<IRecord>>();
            if (!recordsFilteredByDate.AnySave())
            {
                return false;
            }

            foreach (var record in recordsFilteredByDate)
            {
                foreach (var term in modelInput.FilterTerms)
                {
                    var distinctMatchedDescription = GetMatchedDistinctDescription(record.Description, term);
                    record.DistinctDescription = distinctMatchedDescription;
                    if (string.IsNullOrEmpty(distinctMatchedDescription))
                    {
                        continue;
                    }
                    if (matchedRecords.ContainsKey(distinctMatchedDescription))
                    {
                        matchedRecords[distinctMatchedDescription].Add(record);
                    }
                    else
                    {
                        matchedRecords.Add(distinctMatchedDescription, new List<IRecord>() { record });
                    }
                    break;
                }
            }
            return matchedRecords.Any();
        }
    }
}
