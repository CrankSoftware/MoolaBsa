using Moola.Bsa.Logic.Interfaces.Analyser;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Model;

namespace Moola.Bsa.Logic.Services
{
    public class AnalyzerInput : IAnalyzerInput
    {
        public IModel Model { get;}

        public IModelInput ModelInput { get;}

        public AnalyzerInput(IModel model, IModelInput input)
        {
            Model = model;
            ModelInput = input;
        }
    }
}
