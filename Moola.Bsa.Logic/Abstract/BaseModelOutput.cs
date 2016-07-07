using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.Interfaces.Output;
using Moola.Bsa.Logic.Interfaces;

namespace Moola.Bsa.Logic.Abstract
{
    public abstract class BaseModelOutput:IModelOutput
    {

        public int Count { get; set; }

        public double Sum { get; set; }

        /// <summary>
        /// The matching records
        /// </summary>
        public List<IRecord> Records { get; set; }
    }
}
