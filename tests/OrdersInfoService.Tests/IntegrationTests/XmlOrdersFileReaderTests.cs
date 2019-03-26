using NUnit.Framework;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.IO;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.IntegrationTests
{
    [TestFixture]
    public class XmlOrdersFileReaderTests
    {
        private string xmlPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.xml");
        private string noXmlPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests.txt");
        private string xmlPathNoData = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-no-data.xml");
        private string xmlPathWrongSchema = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles\\test-requests-wrong-schema.xml");

        [Test]
        public void ShouldHaveFileErrorStatusWhenPassedIncorrectFileExtension()
        {
            var reader = new XmlOrdersFileReader(noXmlPath);

            Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
        }

        [Test]
        public void ShouldHaveEmptyStatusBeforeCallingRead()
        {
            var reader = new XmlOrdersFileReader(xmlPath);

            Assert.That(ReaderStatus.Empty, Is.EqualTo(reader.Status));
        }

        [Test]
        public async Task ShouldReturnOrders()
        {
            var reader = new XmlOrdersFileReader(xmlPath);

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(4, Is.EqualTo(list.Count));
                Assert.That(ReaderStatus.Completed, Is.EqualTo(reader.Status));
            });
        }

        [Test]
        public async Task ShouldHaveDeserializatoinErrorWhenPassedAnEmptyFile()
        {
            var reader = new XmlOrdersFileReader(xmlPathNoData);

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
            var reader = new XmlOrdersFileReader(xmlPathWrongSchema);

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
            var reader = new XmlOrdersFileReader("nonexisting.xml");

            var list = await reader.ReadOrderFileAsync();

            Assert.Multiple(() =>
            {
                Assert.That(null, Is.EqualTo(list));
                Assert.That(ReaderStatus.FileError, Is.EqualTo(reader.Status));
            });
        }
    }
}
