using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;

namespace Moola.Bsa.Logic.Interfaces.Model
{
    public interface IModel
    {
        string ModelName { get; }
        IModelOutput Analyze(IModelInput input);
    }
}
