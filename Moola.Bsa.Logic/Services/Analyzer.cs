﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Interfaces.Analyser;

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
                return null;
            }

            return new AnalyzerOutput(input.Model, input.Model.Analyze(input.ModelInput));
        }

        public IEnumerable<IAnalyzerOutput> Execute(IEnumerable<IAnalyzerInput> inputs)
        {
            var analyzerInputs = inputs.ToList();
            ConcurrentBag<IAnalyzerOutput> concurrentResult = new ConcurrentBag<IAnalyzerOutput>();
            if (!analyzerInputs.AnySave())
            {
                return new List<IAnalyzerOutput>();
            }

            Parallel.ForEach(analyzerInputs, input =>
            {
                concurrentResult.Add(new AnalyzerOutput(input.Model, input.Model.Analyze(input.ModelInput)));
            });
            return concurrentResult;
        }
    }
}
