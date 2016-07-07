using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Interfaces.Model
{
    public interface IModel
    {
        string ModelName { get; }
        IModelOutput Analyze(IModelInput input);
    }
}
