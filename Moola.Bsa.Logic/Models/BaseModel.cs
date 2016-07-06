using Moola.Bsa.Logic.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Models
{
    public abstract class BaseModel : IModel
    {
        public abstract string ModelName { get; protected set; }

        public abstract IEnumerable<IModelOutput> Process(IModelInput input);

        protected string GetDistinctDescription(string description, string searchTerm)
        {
            if (string.IsNullOrEmpty(description))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(searchTerm))
            {
                return description;
            }
            
            return description.Substring(0, description.ToLowerInvariant().IndexOf(searchTerm.ToLowerInvariant(),StringComparison.InvariantCulture) + searchTerm.Length - 1);
        }
    }
}
