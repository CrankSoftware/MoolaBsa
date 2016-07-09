using Moola.Bsa.Logic.Interfaces.Analyser;
using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Services
{
    public class AnalyzerOutput : IAnalyzerOutput
    {
        public IModel Model { get;}
        
        public IModelOutput ModelOutput { get;}

        public AnalyzerOutput(IModel model, IModelOutput output)
        {
            Model = model;
            ModelOutput = output;
        }
    }
}
