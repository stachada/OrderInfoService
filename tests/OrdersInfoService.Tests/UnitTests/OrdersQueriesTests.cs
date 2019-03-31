using NUnit.Framework;
using OrderInfoService.WinFormsApp;
using OrderInfoService.WinFormsApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersInfoService.Tests.UnitTests
{
    [TestFixture]
    public class OrdersQueriesTests
    {
        private IOrdersQueries _ordersQueries;

        public OrdersQueriesTests()
        {
            _ordersQueries = new OrdersQueries(new OrdersInMemoryDbStub());
        }

        [Test]
        public void GetAllOrders_ShouldReturnAllOrders()
        {
            var result = _ordersQueries.GetAllOrders();

            Assert.That(8, Is.EqualTo(result.Count));
        }

        [Test]
        public void GetOrdersAmount_ShouldReturnCorrectAmount()
        {
            var result = _ordersQueries.GetOrdersAmount();

            Assert.That(276.5, Is.EqualTo(result));
        }

        [Test]
        [TestCase("1", 145)]
        [TestCase("2", 29)]
        [TestCase("3", 50)]
        [TestCase("4", 52.5)]
        [TestCase("5", 0)] // non existing
        public void GetOrdersAmountForClient_ShouldReturnCorrectAmount(
            string clientId, double expectedAmount)
        {
            var result = _ordersQueries.GetOrdersAmountForClient(clientId);

            Assert.That(expectedAmount, Is.EqualTo(result));
        }

        [Test]
        public void GetOrdersQuantity_ShouldReturnCorrectCount()
        {
            var result = _ordersQueries.GetOrdersQuantity();

            Assert.That(8, Is.EqualTo(result));
        }

        [Test]
        [TestCase("1", 3)]
        [TestCase("2", 2)]
        [TestCase("3", 2)]
        [TestCase("4", 1)]
        [TestCase("5", 0)] // non existing
        public void GetOrdersQuantityForClient_ShouldReturnCorrectCount(
            string clientId, int expectedCount)
        {
            var result = _ordersQueries.GetOrdersQuantityForClient(clientId);

            Assert.That(expectedCount, Is.EqualTo(result));
        }

        [Test]
        public void GetOrdersAverageAmount_ShouldReturnCorrectAmount()
        {
            var result = _ordersQueries.GetOrdersAverageAmount();

            Assert.That(34.56, Is.EqualTo(result));
        }

        [Test]
        [TestCase("1", 48.33)]
        [TestCase("2", 14.5)]
        [TestCase("3", 25)]
        [TestCase("4", 52.5)]
        [TestCase("5", 0)] // non existings
        public void GetOrdersAverageAmountForClient_ShouldReturnCorrectAmount(
            string clientId, double expectedAmount)
        {
            var result = _ordersQueries.GetOrdersAverageAmountForClient(clientId);

            Assert.That(expectedAmount, Is.EqualTo(result));
        }

        [Test]
        [TestCase("1", 3)]
        [TestCase("2", 2)]
        [TestCase("3", 2)]
        [TestCase("4", 1)]
        [TestCase("5", 0)]
        public void GetOrdersForClient_ShouldReturnAllClientsOrders(
            string clientId, int expectedCount)
        {
            var result = _ordersQueries.GetOrdersForClient(clientId);

            Assert.That(expectedCount, Is.EqualTo(result.Count));
        }

        [Test]
        [TestCase(0, 6.00, 2)]
        [TestCase(6.00, 11.00, 4)]
        [TestCase(11.0, 16.0, 2)]
        [TestCase(16.0, 25.00, 0)]
        [TestCase(0, 16, 8)]
        public void GetOrdersInPriceRange_ShouldReturnAllRelevantOrders(
            double minPrice, double maxPrice, int expectedResultsCount)
        {
            var result = _ordersQueries.GetOrdersInPriceRange(minPrice, maxPrice);

            Assert.That(expectedResultsCount, Is.EqualTo(result.Count));
        }

        [Test]
        public void GetOrdersQuantityGroupedByName_ShouldReturnCorrectCount()
        {
            var result = _ordersQueries.GetOrdersQuantityGroupedByName()
                .OrderBy(g => g.Name).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(5, Is.EqualTo(result.Count));
                Assert.That("Bułka", Is.EqualTo(result[0].Name));
                Assert.That(3, Is.EqualTo(result[0].Quantity));
                Assert.That("Pomarańcza", Is.EqualTo(result[4].Name));
                Assert.That(9, Is.EqualTo(result[4].Quantity));
            });
        }

        [Test]
        [TestCase("1", 2)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 1)]
        [TestCase("5", 0)]
        public void GetOrdersQuantityGroupedByNameForClient_ShouldReturnCorrectCount(
            string clientId, int expectedCount)
        {
            var result = _ordersQueries.GetOrdersQuantityGroupedByNameForClient(clientId);

            Assert.That(expectedCount, Is.EqualTo(result.Count));
        }

        [Test]
        public void GetClientIds_ShouldReturnAllDistinctIds()
        {
            var result = _ordersQueries.GetClientIds();

            Assert.That(4, Is.EqualTo(result.Count));
        }
    }
}
