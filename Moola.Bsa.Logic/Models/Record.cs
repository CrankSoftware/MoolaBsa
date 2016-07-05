using Moola.Bsa.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moola.Bsa.Logic.Models
{
    public class Record : IRecord
    {
        public double Amount { get; set; }

        public string Description { get; set; }

        public double RunningBalance { get; set; }

        public DateTime TransactionDate { get; set; }


        public override string ToString()
        {
            return this.TransactionDate + ", " + this.Amount + ": " + this.Description;
        }
    }
}
