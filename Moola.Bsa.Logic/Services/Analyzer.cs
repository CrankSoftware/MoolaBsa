﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            ConcurrentBag<IAnalyzerOutput> concurrentResult = new ConcurrentBag<IAnalyzerOutput>();
            if (!inputs.AnySave())
            {
                return new List<IAnalyzerOutput>();
            }

            Parallel.ForEach(inputs, input =>
            {
                concurrentResult.Add(new AnalyzerOutput(input.Model, input.Model.Process(input.ModelInput)));
            });
            return concurrentResult;
        }
    }
}
