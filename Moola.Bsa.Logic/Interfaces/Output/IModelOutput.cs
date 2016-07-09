using System.Collections.Generic;

namespace Moola.Bsa.Logic.Interfaces.Output
{
    public interface IModelOutput:ICount,ISum
    {
        /// <summary>
        /// The matching records
        /// </summary>
        List<IRecord> Records { get; set; }
    }
}
