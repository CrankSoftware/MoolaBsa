using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Analyser;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Model;

namespace Moola.Bsa.Logic.Services
{
    public class AnalyzerInput : IAnalyzerInput
    {
        public IModel Model { get; private set; }

        public IModelInput ModelInput { get; private set; }

        public AnalyzerInput(IModel model, IModelInput input)
        {
            Model = model;
            ModelInput = input;
        }
    }
}
