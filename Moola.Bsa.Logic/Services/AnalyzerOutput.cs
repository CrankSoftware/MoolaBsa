using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Analyser;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Model;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Services
{
    public class AnalyzerOutput : IAnalyzerOutput
    {
        public IModel Model { get; private set; }
        
        public IModelOutput ModelOutput { get; private set; }

        public AnalyzerOutput(IModel model, IModelOutput output)
        {
            Model = model;
            ModelOutput = output;
        }
    }
}
