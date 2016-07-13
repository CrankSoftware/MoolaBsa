using System.Collections.Generic;

namespace Moola.Bsa.Logic.Interfaces.Analyser
{
    public interface IAnalyzer
    {
        IEnumerable<IAnalyzerOutput> ExecuteMultipleModels(IEnumerable<IAnalyzerInput> inputs);
        IAnalyzerOutput Execute(IAnalyzerInput inputs);
    }
}
