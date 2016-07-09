using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Model;

namespace Moola.Bsa.Logic.Interfaces.Analyser
{
    public interface IAnalyzerInput
    {
        IModel Model { get;}
        IModelInput ModelInput { get;}
    }
}
