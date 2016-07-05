using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Interfaces.Analyser;

namespace Moola.Bsa.Logic.Services
{
    public class Analyzer : IAnalyzer
    {
        public IEnumerable<IAnalyzerOutput> Execute(IAnalyzerInput input)
        {
            if (input == null)
            {
                return new List<IAnalyzerOutput>();
            }

            return Execute(new List<IAnalyzerInput>() {input});
        }

        public IEnumerable<IAnalyzerOutput> Execute(IEnumerable<IAnalyzerInput> inputs)
        {
            if (!inputs.AnySave())
            {
                return new List<IAnalyzerOutput>();
            }

            return inputs.Select(i => new AnalyzerOutput(i.Model, i.Model.Process(i.ModelInput)));
        }
    }
}
