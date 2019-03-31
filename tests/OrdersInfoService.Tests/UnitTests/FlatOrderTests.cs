using NUnit.Framework;
using OrderInfoService.WinFormsApp.Core;

namespace OrdersInfoService.Tests.UnitTests
{
    [TestFixture]
    public class FlatOrderTests
    {
        [Test]
        public void IsValidShouldReturnFalseForInvalidOrder()
        {
            var order = new FlatOrder(null, null, null, null, null);

            Assert.That(order.IsValid, Is.False);
        }

        [Test]
        public void IsValidShouldReturnTrueForValidOrder()
        {
            var order = new FlatOrder("1", 1, "chleb", 1, 1);

            Assert.That(order.IsValid, Is.True);
        }

        [TestCase("aaaaaaa")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("aaa aa")]
        public void ValidateShouldProperlyValidateClientId(string clientId)
        {
            var order = new FlatOrder(clientId, 1, "chleb", 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidateRequestId()
        {
            var order = new FlatOrder("1", null, "chleb", 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void ValidateShouldProperlyValidateName(string name)
        {
            var order = new FlatOrder("1", 1, name, 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValiedNameAgainstItsLength()
        {
            var order = new FlatOrder("1", 1, new string('a', 256), 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidateQuantity()
        {
            var order = new FlatOrder("1", 1, "chleb", null, 1);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ValidateShouldProperlyValidatePrice()
        {
            var order = new FlatOrder("1", 1, "chleb", 1, null);

            Assert.Multiple(() =>
            {
                Assert.That(order.IsValid, Is.False);
                Assert.That(order.Validate().Count, Is.EqualTo(1));
            });
        }
    }
}
