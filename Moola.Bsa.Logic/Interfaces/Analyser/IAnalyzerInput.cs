using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
