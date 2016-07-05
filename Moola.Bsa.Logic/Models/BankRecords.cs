using Moola.Bsa.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moola.Bsa.Logic.Models
{
    public class BankRecords : IRecords
    {
        public string Code { get; private set; }

        public DateTime CreateTime { get; private set; }


        public string Descriptiopn { get; private set; }


        public string OwnnerName { get; private set; }

        public List<IRecord> Records { get; private set; }

        public override string ToString()
        {
            return this.Code + " (" + this.Records?.Count + ")";
        }
    }
}
