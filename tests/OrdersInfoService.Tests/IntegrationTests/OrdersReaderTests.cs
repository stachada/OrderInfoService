using NUnit.Framework;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.Collections.Generic;
using System.IO;

namespace OrdersInfoService.Tests.IntegrationTests
{
    [TestFixture]
    public class OrdersReaderTests
    {
        private List<string> xmlPaths = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.xml") };
        private List<string> jsonPaths = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.json") };
        private List<string> csvPaths = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.csv") };
        private List<string> txtPaths = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.txt") };

        private List<string> xmlPathsNoData = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.xml") };
        private List<string> jsonPathsNoData = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.json") };
        private List<string> csvPathsNoData = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.csv") };

        private List<string> xmlPathsWrongSchema = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.xml") };
        private List<string> jsonPathsWrongSchema = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.json") };
        private List<string> csvPathsWrongSchema = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.csv") };
        private List<string> csvPathsWrongSchemaSameNumberOfColumns = new List<string> { Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema1.csv") };

        [Test]
        public void ShouldReturnNoDataFromFaultedFiles()
        {
            var paths = new List<string>();
            paths.AddRange(xmlPathsWrongSchema);
            paths.AddRange(jsonPathsNoData);
            paths.AddRange(csvPathsWrongSchemaSameNumberOfColumns);
            //paths.AddRange(txtPaths);

            var reader = new OrdersReader();
            var list = reader.ReadOrdersFromFiles(paths);

            Assert.That(0, Is.EqualTo(list.Count));
        }

        [Test]
        public void ShouldReturnDataFromCorrectFileMixedWithWrongFiles()
        {
            var paths = new List<string>();
            paths.AddRange(xmlPaths);
            paths.AddRange(jsonPathsNoData);
            paths.AddRange(csvPathsWrongSchemaSameNumberOfColumns);
            //paths.AddRange(txtPaths);

            var reader = new OrdersReader();
            var list = reader.ReadOrdersFromFiles(paths);

            Assert.That(4, Is.EqualTo(list.Count));
        }

        [Test]
        public void ShouldReturnCorrectInfoAboutFilesThatWhereNotLoaded()
        {
            var paths = new List<string>();
            paths.AddRange(xmlPaths);
            paths.AddRange(jsonPathsNoData);
            paths.AddRange(csvPathsWrongSchemaSameNumberOfColumns);
            paths.AddRange(new List<string> { "nonexisting.xml" });
            //paths.AddRange(txtPaths);

            var reader = new OrdersReader();
            reader.ReadOrdersFromFiles(paths);
            var info = reader.GetSkippedFilesInfo();
        }
    }
}
