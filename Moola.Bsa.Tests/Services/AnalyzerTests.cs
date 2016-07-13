using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Tests.TestData;
using System.Collections.Generic;
using System.Linq;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Models;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;
using Moola.Bsa.Logic.Services;
using Moola.Bsa.Logic.Exceptions;
using Moola.Bsa.Logic.Interfaces.Analyser;

namespace Moola.Bsa.Tests.Services
{
    [TestClass()]
    public class AnalyzerTests
    {
        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AnalyzerTestNullInputException()
        {
            Analyzer.Instance.Execute(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BsaInputParameterException))]
        public void AnalyzerTestEmptyListInputException()
        {
            Analyzer.Instance.ExecuteMultipleModels(new List<IAnalyzerInput>());
        }

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
            Assert.IsNotNull(outputs.ModelOutput);
            Assert.IsTrue(outputs.ModelOutput.Count==3);
            Assert.IsNotNull((outputs.ModelOutput as AccountConductOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as AccountConductOverallSummary).AccountConductGroupSummaries.Count== 2);
            //Test Parallel
            var outputs2 = Analyzer.Instance.ExecuteMultipleModels(inputs);
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
            Assert.IsNotNull(outputs.ModelOutput);
            Assert.IsTrue(outputs.ModelOutput.Count == 6);
            Assert.IsNotNull((outputs.ModelOutput as GamblingOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as GamblingOverallSummary).GamblingGroupSummaries.Count == 4);
            //Test Parallel
            var outputs2 = Analyzer.Instance.ExecuteMultipleModels(inputs);
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
            Assert.IsNotNull(outputs.ModelOutput);
            Assert.IsTrue(outputs.ModelOutput.Count == 4);
            Assert.IsNotNull((outputs.ModelOutput as FinanceWithdrawalsOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as FinanceWithdrawalsOverallSummary).GamblingGroupSummaries.Count == 2);
            //Test Parallel
            var outputs2 = Analyzer.Instance.ExecuteMultipleModels(inputs);
            Assert.IsTrue(outputs2.AnySave());
        }

        [TestMethod()]
        public void ExecuteForeignExchangeModelTest()
        {
            var testData = TestRecords.GetTestData();
            Assert.IsNotNull(testData);

            var searchTerm = new List<string> { "Currency", "Conversion"};
            var inputs = testData.Select(records => new AnalyzerInput(ForeignExchangeModel.Instance, new ForeignExchangeInput()
            {
                DateRangeInDays = 90,
                FilterTerms = searchTerm,
                BankRecords = records
            })).ToList();

            //Test Singel One
            var outputs = Analyzer.Instance.Execute(inputs.FirstOrDefault(i => i.ModelInput.BankRecords.Code == "SNCT7W"));
            Assert.IsNotNull(outputs);
            Assert.IsNotNull(outputs.ModelOutput);
            Assert.IsTrue(outputs.ModelOutput.Count == 7);
            Assert.IsNotNull((outputs.ModelOutput as ForeignExchangeOverallSummary));
            Assert.IsTrue((outputs.ModelOutput as ForeignExchangeOverallSummary).ForeignExchangeGroupSummaries.Count == 1);
            //Test Parallel
            var outputs2 = Analyzer.Instance.ExecuteMultipleModels(inputs);
            Assert.IsTrue(outputs2.AnySave());
        }
    }
}