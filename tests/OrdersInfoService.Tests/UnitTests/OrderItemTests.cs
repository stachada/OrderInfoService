using NUnit.Framework;
using OrderInfoService.WinFormsApp.Core;

namespace OrdersInfoService.Tests.UnitTests
{
    [TestFixture]
    public class OrderItemTests
    {
        [Test]
        public void IsValidShouldReturnFalseForInvalidOrderItem()
        {
            var order = new OrderItem(null, null, null);

            Assert.That(order.IsValid, Is.False);
        }

        [Test]
        public void IsValidShouldReturnTrueForValidOrderItem()
        {
            var order = new OrderItem("chleb", 1, 1);

            Assert.That(order.IsValid, Is.True);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ValidateShouldProperlyValidateName(string name)
        {
            var order = new OrderItem(name, 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValiedNameAgainstItsLength()
        {
            var order = new OrderItem(new string('a', 256), 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidateQuantity()
        {
            var order = new OrderItem("chleb", null, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidatePrice()
        {
            var order = new OrderItem("chleb", 1, null);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }
    }
}
