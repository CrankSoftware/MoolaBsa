using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Interfaces.Analyser;
using Moola.Bsa.Logic.Exceptions;

namespace Moola.Bsa.Logic.Services
{
    public class Analyzer : IAnalyzer
    {
        private static Analyzer _instance;
        public static Analyzer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Analyzer();
                }
                return _instance ?? new Analyzer();
            }
        }

        public IAnalyzerOutput Execute(IAnalyzerInput input)
        {
            if (input == null)
            {
                throw new BsaInputParameterException("The Analyzer Input value cannot be null or empty");
            }

            return new AnalyzerOutput(input.Model, input.Model.Analyze(input.ModelInput));
        }

        public IEnumerable<IAnalyzerOutput> ExecuteMultipleModels(IEnumerable<IAnalyzerInput> inputs)
        {
            var analyzerInputs = inputs.ToList();
            ConcurrentBag<IAnalyzerOutput> concurrentResult = new ConcurrentBag<IAnalyzerOutput>();
            if (!analyzerInputs.AnySave())
            {
                throw new BsaInputParameterException("The Analyzer Input value cannot be null or empty");
            }

            Parallel.ForEach(analyzerInputs, input =>
            {
                concurrentResult.Add(new AnalyzerOutput(input.Model, input.Model.Analyze(input.ModelInput)));
            });
            return concurrentResult;
        }
    }
}
