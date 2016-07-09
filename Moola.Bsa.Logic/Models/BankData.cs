using Moola.Bsa.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace Moola.Bsa.Logic.Models
{
    public class BankData : IRecords
    {
        public string Code { get;}

        public DateTime CreateTime { get;}

        public string Descriptiopn { get;}

        public IList<IRecord> Records { get; set; }

        public BankData(string code,string description="")
        {
            Code = code;
            Descriptiopn = description;
            CreateTime = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return Code + " (" + Records?.Count + ")";
        }
    }
}
