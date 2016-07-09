using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using System;

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

            if (description.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant()))
            {
                return description.Substring(0, description.ToLowerInvariant().IndexOf(searchTerm.ToLowerInvariant(), StringComparison.InvariantCulture) + searchTerm.Length);
            }

            return string.Empty;
        }
    }
}
