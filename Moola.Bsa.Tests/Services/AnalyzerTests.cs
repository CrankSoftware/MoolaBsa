using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Tests.TestData;
using System.Collections.Generic;
using System.Linq;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Models;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;
using Moola.Bsa.Logic.Services;

namespace Moola.Bsa.Tests.Services
{
    [TestClass()]
    public class AnalyzerTests
    {
        [TestMethod()]
        public void ExecuteAccountConduceModelTest()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string> { "Dishonour Fee", "Dishonour", "Failed", "Reversal", "Unpaid", "Overdraft" };
            var inputs= testData.Select(records => new AnalyzerInput(AccountConductModel.Instance,new AccountConductInput()
                                        {
                                                DateRangeInDays = 90,
                                                FilterTerms =  searchTerm,
                                                BankRecords = records
            })).ToList();

            //Test Singel One
            var outputs = Analyzer.Instance.Execute(inputs.FirstOrDefault(i=>i.ModelInput.BankRecords.Code== "WVBBKJ"));
            Assert.IsNotNull(outputs);
            Assert.IsTrue(outputs.ModelOutput.Count==3);
            Assert.IsNotNull((outputs.ModelOutput as AccountConductOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as AccountConductOverallSummary).AccountConductGroupSummaries.Count== 2);
            //Test Parallel
            var outputs2 = Analyzer.Instance.Execute(inputs);
            Assert.IsTrue(outputs2.AnySave());
        }

        [TestMethod()]
        public void ExecuteGamblingModelTest()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string> { "Casino", "Digimedia", "Racing", "Seabrook", "Sky City", "Slots", "TAB", "ThePalac", "B365","Sportsbet" };
            var inputs = testData.Select(records => new AnalyzerInput(GamblingModel.Instance, new GamblingInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = records
            })).ToList();

            //Test Singel One
            var outputs = Analyzer.Instance.Execute(inputs.FirstOrDefault(i => i.ModelInput.BankRecords.Code == "RE85MC"));
            Assert.IsNotNull(outputs);
            Assert.IsTrue(outputs.ModelOutput.Count == 6);
            Assert.IsNotNull((outputs.ModelOutput as GamblingOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as GamblingOverallSummary).GamblingGroupSummaries.Count == 4);
            //Test Parallel
            var outputs2 = Analyzer.Instance.Execute(inputs);
            Assert.IsTrue(outputs2.AnySave());
        }

        [TestMethod()]
        public void ExecuteFinanceWithdrawalsModelTest()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string> { "Finance","Loan", "Admiral", "Avanti", "Cashburst", "Cash Converters", "Cash in a Flash",
                                                "Cash Relief", "Cash Train", "CC Finance", "Chester", "Ferratum", "Handy Cash", "Harmoney",
                                                "Instant Finance", "Loan Plus", "Loans 2 Go", "Payday Advance", "Pretty Penny Loans", "Rapid Loans",
                                                "Save My Bacon", "Seed", "Smart Cash", "Smart Shop", "SMB","Superloans", "Teleloans"};
            var inputs = testData.Select(records => new AnalyzerInput(FinanceWithdrawalsModel.Instance, new FinanceWithdrawalsInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = records
            })).ToList();

            //Test Singel One
            var outputs = Analyzer.Instance.Execute(inputs.FirstOrDefault(i => i.ModelInput.BankRecords.Code == "RE85MC"));
            Assert.IsNotNull(outputs);
            Assert.IsTrue(outputs.ModelOutput.Count == 4);
            Assert.IsNotNull((outputs.ModelOutput as FinanceWithdrawalsOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as FinanceWithdrawalsOverallSummary).GamblingGroupSummaries.Count == 2);
            //Test Parallel
            var outputs2 = Analyzer.Instance.Execute(inputs);
            Assert.IsTrue(outputs2.AnySave());
        }
    }
}