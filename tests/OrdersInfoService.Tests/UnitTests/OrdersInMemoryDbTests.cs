using NSubstitute;
using NUnit.Framework;
using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.UnitTests
{
    [TestFixture]
    public class OrdersInMemoryDbTests
    {
        [Test]
        public async Task LoadOrdersAsyncShouldLoadAllOrdersFromOrdersReader()
        {
            var data = GenerateData();
            var reader = Substitute.For<IOrdersReader>();
            reader.ReadOrdersFromFiles(Arg.Any<IList<string>>()).ReturnsForAnyArgs(data);
            var inMemoryDb = new OrdersInMemoryDb(reader);

            await inMemoryDb.LoadOrdersAsync(new List<string> { "path1", "path2" });

            Assert.Multiple(() =>
            {
                Assert.That(inMemoryDb.FlatOrders.Count, Is.EqualTo(2));
                Assert.That(inMemoryDb.InvalidOrders.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task ResetOrdersAsyncShouldClearInMemoryDatabase()
        {
            var data = GenerateData();
            var reader = Substitute.For<IOrdersReader>();
            reader.ReadOrdersFromFiles(Arg.Any<IList<string>>()).ReturnsForAnyArgs(data);
            var inMemoryDb = new OrdersInMemoryDb(reader);

            await inMemoryDb.LoadOrdersAsync(new List<string> { "path1", "path2" });
            inMemoryDb.ClearDatabase();

            Assert.Multiple(() =>
            {
                Assert.That(inMemoryDb.FlatOrders.Count, Is.EqualTo(0));
                Assert.That(inMemoryDb.InvalidOrders.Count, Is.EqualTo(0));
                reader.Received().Reset();
            });
        }

        [Test]
        public void SkippedFilesInfoShouldCallReadersMethod()
        {
            var reader = Substitute.For<IOrdersReader>();
            var inMemoryDb = new OrdersInMemoryDb(reader);

            inMemoryDb.SkippedFilesInfo();

            reader.Received().GetSkippedFilesInfo();
        }

        [Test]
        public void LoadedFilesInfoShouldCallReadersMethod()
        {
            var reader = Substitute.For<IOrdersReader>();
            var inMemoryDb = new OrdersInMemoryDb(reader);

            inMemoryDb.LoadedFilesInfo();

            reader.Received().GetLoadedFilesInfo();
        }

        private List<FlatOrder> GenerateData()
        {
            var list = new List<FlatOrder>
            {
                new FlatOrder("1", 1, "chleb", 1, 1),
                new FlatOrder("1", 1, "chleb", 1, 1),
                new FlatOrder(null, 1, "chleb", 1, 1)
            };
            return list;
        }
    }
}
