using NUnit.Framework;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.IO;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.IntegrationTests
{
    [TestFixture]
    public class CsvOrdersFileReaderTests
    {
        private string csvPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.csv");
        private string noCsvPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.txt");
        private string csvPathNoData = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.csv");
        private string csvPathWrongSchema = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.csv");

        [Test]
        public void ShouldShouldHaveFileErrorStatusWhenPassedIncorrectFileExtension()
        {
            var reader = new CsvOrdersFileReader(noCsvPath);

            Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
        }

        [Test]
        public void ShouldHaveEmptyStatusBeforeCallingRead()
        {
            var reader = new CsvOrdersFileReader(csvPath);

            Assert.That(ReaderStatus.Empty, Is.EqualTo(reader.Status));
        }

        [Test]
        public async Task ShouldReturnOrders()
        {
            var reader = new CsvOrdersFileReader(csvPath);

            var result = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(4, Is.EqualTo(result.Count));
                Assert.That(ReaderStatus.Completed, Is.EqualTo(reader.Status));
            });
        }

        [Test]
        public async Task ShouldHaveDeserializatoinErrorWhenPassedAnEmptyFile()
        {
            var reader = new CsvOrdersFileReader(csvPathNoData);

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(null, Is.EqualTo(list));
                Assert.That(ReaderStatus.DeserializationError, Is.EqualTo(reader.Status));
            });
        }

        [Test]
        public async Task ShouldHaveDeserializationErrorWhenPassedAFileWithWrongSchema()
        {
            var reader = new CsvOrdersFileReader(csvPathWrongSchema);

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(null, Is.EqualTo(list));
                Assert.That(ReaderStatus.DeserializationError, Is.EqualTo(reader.Status));
            });
        }

        [Test]
        public async Task ShouldHaveFileErrorStatusWhenPassedANonExistingFile()
        {
            var reader = new CsvOrdersFileReader("nonexisting.csv");

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(null, Is.EqualTo(list));
                Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
            });
        }
    }
}
