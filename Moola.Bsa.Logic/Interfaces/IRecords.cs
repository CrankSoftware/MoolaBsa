using System.Collections.Generic;
using Moola.Bsa.Logic.Models.Inputs;
using System;

namespace Moola.Bsa.Logic.Interfaces
{
    public interface IRecords
    {
        //The bank statement code
        string Code { get;}
        //The record's ownder name
        string OwnnerName { get; }
        string Descriptiopn { get; }
        DateTime CreateTime { get; }
        List<IRecord> Records { get; }
    }
}
