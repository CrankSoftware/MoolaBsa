using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using System;
using System.Text.RegularExpressions;

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

            if (!matchedWord.Success)
            {
                return string.Empty;
            }

            return description.Substring(0, description.ToLowerInvariant().IndexOf(matchedWord.Value.ToLowerInvariant(), StringComparison.InvariantCulture) + matchedWord.Length);

        }
    }
}
