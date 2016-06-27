namespace Moola.Bsa.Logic.Models.Inputs
{
    /// <summary>
    /// Encapsulates a bank statement record
    /// </summary>
    public class Record
    {
        /// <summary>
        /// The date of the transaction
        /// </summary>
        public System.DateTime TransactionDate { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        /// <remarks>Negative amounts are withdrawals</remarks>
        /// <remarks>Positive amounts are deposits</remarks>
        public double Amount { get; set; }

        /// <summary>
        /// The balance of the account after the transaction
        /// </summary>
        public double RunningBalance { get; set; }
        
        /// <summary>
        /// The description of the transaction
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return this.TransactionDate + ", " + this.Amount + ": " + this.Description;
        }
    }
}
