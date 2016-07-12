using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;
using Moola.Bsa.Tests.TestData;
using System.Collections.Generic;
using System.Linq;
using Moola.Bsa.Logic.Models;

namespace Moola.Bsa.Tests.Models
{

    [TestClass()]
    public class FinanceWithdrawalsModelTests
    {
        [TestMethod()]
        public void FinanceWithdrawalsModellTestSuccess()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string>
            {
                "Finance","Loan", "Admiral", "Avanti", "Cashburst", "Cash Converters", "Cash in a Flash",
                "Cash Relief", "Cash Train", "CC Finance", "Chester", "Ferratum", "Handy Cash", "Harmoney",
                "Instant Finance", "Loan Plus", "Loans 2 Go", "Payday Advance", "Pretty Penny Loans", "Rapid Loans",
                 "Save My Bacon", "Seed", "Smart Cash", "Smart Shop", "SMB","Superloans", "Teleloans"
            };

            var recorddata = testData.FirstOrDefault(data => data.Code == "RE85MC");
            var input = new FinanceWithdrawalsInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = recorddata
            };

            var outputs = FinanceWithdrawalsModel.Instance.Analyze(input);
            Assert.IsNotNull(outputs as FinanceWithdrawalsOverallSummary);
            Assert.IsTrue((outputs as FinanceWithdrawalsOverallSummary).GamblingGroupSummaries.Count == 2);
            Assert.IsTrue((outputs as FinanceWithdrawalsOverallSummary).Count == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void FinanceWithdrawalsModelTestNullInputException()
        {
            FinanceWithdrawalsModel.Instance.Analyze(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void FinanceWithdrawalsModelTest0DateRangeInDaysException()
        {
            var input = new GamblingInput()
            {
                DateRangeInDays = 0,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            FinanceWithdrawalsModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void FinanceWithdrawalsModelTestNullBankRecordsException()
        {
            var input = new GamblingInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            FinanceWithdrawalsModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void FinanceWithdrawalsModelTestNullRecordsException()
        {
            var bankRecords = new BankData("fake");
            var input = new GamblingInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = bankRecords
            };
            FinanceWithdrawalsModel.Instance.Analyze(input);
        }
    }
}