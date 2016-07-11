using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;
using Moola.Bsa.Tests.TestData;
using System.Collections.Generic;
using System.Linq;
using Moola.Bsa.Logic.Interfaces.Input;
using Moola.Bsa.Logic.Interfaces.Output;
using System;
using Moola.Bsa.Logic.Models;

namespace Moola.Bsa.Tests.Models
{

    [TestClass()]
    public class GamblingModelTests
    {
        [TestMethod()]
        public void GamblingModelTestSuccess()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string>
            {
                "Casino",
                "Digimedia",
                "Racing",
                "Seabrook",
                "Sky City",
                "Slots",
                "TAB",
                "ThePalac",
                "B365",
                "Sportsbet"
            };

            var recorddata = testData.FirstOrDefault(data => data.Code == "RE85MC");
            var input = new GamblingInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = recorddata
            };

            var outputs = GamblingModel.Instance.Analyze(input);
            Assert.IsNotNull(outputs as GamblingOverallSummary);
            Assert.IsTrue((outputs as GamblingOverallSummary).GamblingGroupSummaries.Count == 4);
            Assert.IsTrue((outputs as GamblingOverallSummary).Count == 6);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void GamblingModelTestNullInputException()
        {
            GamblingModel.Instance.Analyze(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void GamblingModelTest0DateRangeInDaysException()
        {
            var input = new GamblingInput()
            {
                DateRangeInDays = 0,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            GamblingModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void GamblingModelTestNullBankRecordsException()
        {
            var input = new GamblingInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = null
            };
            GamblingModel.Instance.Analyze(input);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void GamblingModelTestNullRecordsException()
        {
            var bankRecords = new BankData("fake");
            var input = new GamblingInput()
            {
                DateRangeInDays = 30,
                FilterTerms = new List<string>(),
                BankRecords = bankRecords
            };
            GamblingModel.Instance.Analyze(input);
        }
    }
}