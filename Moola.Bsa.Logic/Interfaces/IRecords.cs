using System.Collections.Generic;
using System;

namespace Moola.Bsa.Logic.Interfaces
{
    public interface IRecords
    {
        //The bank statement code
        string Code { get;}
        string Descriptiopn { get; }
        DateTime CreateTime { get; }
        IList<IRecord> Records { get; set; }
    }
}
