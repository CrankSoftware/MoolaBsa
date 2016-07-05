using System.Collections.Generic;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Interfaces;
using System;

namespace Moola.Bsa.Tests.TestData
{
    /// <summary>
    /// Holds the bank statement records for a given code
    /// </summary>
    public class CodeData:IRecords
    {
        public string Code { get; set; }

        public DateTime CreateTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Descriptiopn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string OwnnerName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<IRecord> Records { get; set; }

        public override string ToString()
        {
            return this.Code + " (" + this.Records?.Count + ")";
        }
    }
}
