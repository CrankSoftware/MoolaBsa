using Moola.Bsa.Logic.Interfaces;
using System;

namespace Moola.Bsa.Logic.Models
{
    public class Record : IRecord
    {
        public double Amount { get; set; }

        public string Description { get; set; }

        public string DistinctDescription { get; set; }

        public double RunningBalance { get; set; }

        public DateTime TransactionDate { get; set; }


        public override string ToString()
        {
            return TransactionDate + ", " + Amount + ": " + Description;
        }
    }
}
