using System.Collections.Generic;

namespace Moola.Bsa.Logic.Interfaces.Analyser
{
    public interface IAnalyzer
    {
        IEnumerable<IAnalyzerOutput> Execute(IEnumerable<IAnalyzerInput> inputs);
        IAnalyzerOutput Execute(IAnalyzerInput inputs);
    }
}
