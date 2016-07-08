using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Analyser;

namespace Moola.Bsa.Logic.Interfaces
{
    public interface IAnalyzer
    {
        IEnumerable<IAnalyzerOutput> Execute(IEnumerable<IAnalyzerInput> inputs);
        IAnalyzerOutput Execute(IAnalyzerInput inputs);
    }
}
