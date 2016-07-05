using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moola.Bsa.Logic.Interfaces.Output
{
    public interface IModelOutput
    {
        string Description { get; set; }

        int Count { get; set; }

        double Sum { get; set; }

        /// <summary>
        /// The matching records
        /// </summary>
        List<IRecord> Records { get; set; }
    }
}
