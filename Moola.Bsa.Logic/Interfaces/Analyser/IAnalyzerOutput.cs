using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Interfaces.Analyser
{
    public interface IAnalyzerOutput
    {
        IModel Model { get; }
        IEnumerable<IModelOutput> ModelOutput { get; }
    }
}
