using NUnit.Framework;
using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;

namespace OrdersInfoService.Tests.UnitTests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void IsValidShouldReturnFalseForInvalidOrder()
        {
            var order = new Order(null, null, null);

            Assert.That(order.IsValid, Is.False);
        }

        [Test]
        public void IsValidShouldReturnTrueForValidOrder()
        {
            var order = new Order("1", 1, new List<OrderItem>());

            Assert.That(order.IsValid, Is.True);
        }

        [TestCase("aaaaaaa")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("aaa aa")]
        public void ValidateShouldProperlyValidateClientId(string clientId)
        {
            var order = new Order(clientId, 1, new List<OrderItem>());

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidateRequestId()
        {
            var order = new Order("1", null, new List<OrderItem>());

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }
    }
}
