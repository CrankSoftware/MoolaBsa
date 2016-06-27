using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moola.Bsa.Tests.TestData;

namespace Moola.Bsa.Tests
{
    [TestClass]
    public class TestDataGetter
    {
        /// <summary>
        /// An example of how to access the test data
        /// </summary>
        [TestMethod]
        public void GetTestDataShallReturnTestData()
        {
            var testData = TestRecords.GetTestData();

            Assert.IsNotNull(testData);

            var count = testData.SelectMany(i => i.Records).Count();
            //5700 should be enough eh?

            Assert.IsTrue(count > 0);
        }
    }
}
