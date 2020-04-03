namespace EssentialTools.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EssentialTools.Models;

    [TestClass]
    public class UnitTest1
    {
        private IDiscounterHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscounterHelper target = getTestObject();
            decimal total = 200;

            var discountTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9m, discountTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscounterHelper target = getTestObject();

            var ten = target.ApplyDiscount(10);
            var hundred = target.ApplyDiscount(100);
            var fifty = target.ApplyDiscount(50);

            Assert.AreEqual(5, ten, "rabat 10 jest nieprawdiłowy");
            Assert.AreEqual(95, hundred, "rabat 100 jest nieprawdiłowy");
            Assert.AreEqual(45, fifty, "rabat 50 jest nieprawdiłowy");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscounterHelper target = getTestObject();

            var five = target.ApplyDiscount(5);
            var zero = target.ApplyDiscount(0);

            Assert.AreEqual(5, five);
            Assert.AreEqual(0, zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative()
        {
            IDiscounterHelper target = getTestObject();
            target.ApplyDiscount(-1);
        }
    }
}