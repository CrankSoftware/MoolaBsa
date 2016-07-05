using System.Collections.Generic;
using Moola.Bsa.Logic.Interfaces;
using Moola.Bsa.Logic.Models.Inputs;

namespace Moola.Bsa.Logic.Models.Outputs
{
    public class AccountConductGroupSummary : ICount, ISum
    {
        public string Description { get; set; }

        public int Count { get; set; }

        public double Sum { get; set; }
        
        /// <summary>
        /// The matching records
        /// </summary>
        public List<IRecord> Records { get; set; }
    }
}
