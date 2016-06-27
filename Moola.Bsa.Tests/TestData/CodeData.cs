using System.Collections.Generic;
using Moola.Bsa.Logic.Models.Inputs;

namespace Moola.Bsa.Tests.TestData
{
    /// <summary>
    /// Holds the bank statement records for a given code
    /// </summary>
    public class CodeData
    {
        public string Code { get; set; }

        public List<Record> Records { get; set; }

        public override string ToString()
        {
            return this.Code + " (" + this.Records?.Count + ")";
        }
    }
}
