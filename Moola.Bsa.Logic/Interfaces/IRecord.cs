

namespace Moola.Bsa.Logic.Interfaces
{
    /// <summary>
    /// Encapsulates a bank statement record
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// The date of the transaction
        /// </summary>
        System.DateTime TransactionDate { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        /// <remarks>Negative amounts are withdrawals</remarks>
        /// <remarks>Positive amounts are deposits</remarks>
        double Amount { get; set; }

        /// <summary>
        /// The balance of the account after the transaction
        /// </summary>
        double RunningBalance { get; set; }
        
        /// <summary>
        /// The description of the transaction
        /// </summary>
        string Description { get; set; }

    }
}
