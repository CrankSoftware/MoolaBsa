using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Models;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;
using Moola.Bsa.Tests.TestData;
using System.Collections.Generic;
using System.Linq;

namespace Moola.Bsa.Logic.Models.Tests
{
    [TestClass()]
    public class AnalyzerTests
    {
        [TestMethod()]
        public void AccountConductModelTestSuccess()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string>
            {
                "Dishonour Fee",
                "Dishonour",
                "Failed",
                "Reversal",
                "Unpaid",
                "Overdraft"
            };

            var recorddata = testData.FirstOrDefault(data => data.Code == "WVBBKJ");
            var input = new AccountConductInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = recorddata
            };

            var outputs = AccountConductModel.Instance.Analyze(input);
            Assert.IsNotNull(outputs as AccountConductOverallSummary);
            Assert.IsTrue((outputs as AccountConductOverallSummary).AccountConductGroupSummaries.Count == 2);
            Assert.IsTrue((outputs as AccountConductOverallSummary).Count == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AccountConductModelTestNullInputException()
        {
            AccountConductModel.Instance.Analyze(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AccountConductModelTest0DateRangeInDaysException()
        {
            var input = new AccountConductInput()
            {
                DateRangeInDays = 0,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            AccountConductModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AccountConductModelTestNullBankRecordsException()
        {
            var input = new AccountConductInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
             AccountConductModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AccountConductModelTestNullRecordsException()
        {
            var bankRecords = new BankRecords();
            var input = new AccountConductInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = bankRecords
            };
            AccountConductModel.Instance.Analyze(input);
        }
    }
}