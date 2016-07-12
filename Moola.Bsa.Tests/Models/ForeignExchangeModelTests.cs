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
    public class ForeignExchangeModelTests
    {
        [TestMethod()]
        public void ForeignExchangeModelTestSuccess()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string>
            {
                "Currency",
                "Conversion"
            };

            var recorddata = testData.FirstOrDefault(data => data.Code == "SNCT7W");
            var input = new ForeignExchangeInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = recorddata
            };

            var outputs = ForeignExchangeModel.Instance.Analyze(input);
            Assert.IsNotNull(outputs);
            Assert.IsNotNull(outputs as ForeignExchangeOverallSummary);
            Assert.IsTrue((outputs as ForeignExchangeOverallSummary).ForeignExchangeGroupSummaries.Count == 1);
            Assert.IsTrue((outputs as ForeignExchangeOverallSummary).Count == 7);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void ForeignExchangeModelTestNullInputException()
        {
            ForeignExchangeModel.Instance.Analyze(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void ForeignExchangeModelTest0DateRangeInDaysException()
        {
            var input = new ForeignExchangeInput()
            {
                DateRangeInDays = 0,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            ForeignExchangeModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void ForeignExchangeModelTestNullBankRecordsException()
        {
            var input = new ForeignExchangeInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            GamblingModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void ForeignExchangeModelTestNullRecordsException()
        {
            var bankRecords = new BankData("fake");
            var input = new ForeignExchangeInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = bankRecords
            };
            ForeignExchangeModel.Instance.Analyze(input);
        }
    }
}