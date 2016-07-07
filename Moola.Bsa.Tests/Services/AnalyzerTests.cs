using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Logic.Services;
using Moola.Bsa.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moola.Bsa.Logic.ExtensionMethods;
using Moola.Bsa.Logic.Models;
using Moola.Bsa.Logic.Models.Inputs;
using Moola.Bsa.Logic.Models.Outputs;

namespace Moola.Bsa.Logic.Services.Tests
{
    [TestClass()]
    public class AnalyzerTests
    {
        [TestMethod()]
        public void ExecuteTest()
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
            Assert.IsTrue(outputs.FirstOrDefault().ModelOutput.Count==3);
            Assert.IsTrue((outputs.FirstOrDefault().ModelOutput as AccountConductOverallSummary).AccountConductGroupSummaries.Count== 2);
            //Test Parallel
            var outputs2 = Analyzer.Instance.Execute(inputs);
            Assert.IsTrue(outputs.AnySave());
            Assert.IsTrue(outputs2.AnySave());
        }
    }
}