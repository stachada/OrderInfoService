using NUnit.Framework;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.IO;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.IntegrationTests
{
    [TestFixture]
    public class JsonOrdersFileReaderTests
    {
        private string jsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.json");
        private string noJsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.txt");
        private string jsonPathNoData = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.json");
        private string jsonPathWrongSchema = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.json");

        [Test]
        public void ShouldShouldHaveFileErrorStatusWhenPassedIncorrectFileExtension()
        {
            var reader = new XmlOrdersFileReader(noJsonPath);

            Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
        }

        [Test]
        public void ShouldHaveEmptyStatusBeforeCallingRead()
        {
            var reader = new JsonOrdersFileReader(jsonPath);

            Assert.That(ReaderStatus.Empty, Is.EqualTo(reader.Status));
        }

        [Test]
        public async Task ShouldReturnOrders()
        {
            var reader = new JsonOrdersFileReader(jsonPath);

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
            var reader = new JsonOrdersFileReader(jsonPathNoData);

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
            var reader = new JsonOrdersFileReader(jsonPathWrongSchema);

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
            var reader = new JsonOrdersFileReader("nonexisting.json");

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(null, Is.EqualTo(list));
                Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
            });
        }
    }
}
