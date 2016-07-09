using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Interfaces.Analyser
{
    public interface IAnalyzerOutput
    {
        IModel Model { get; }
        IModelOutput ModelOutput { get; }
    }
}
