namespace EssentialTools.Test
{
    using System;
    using System.Linq;
    using EssentialTools.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
            new Product {Name = "Kajak", Category="Sporty Wodne", Price = 275m},
            new Product {Name = "Kamizelka ratunkowa", Category="Sporty Wodne", Price = 48.95m},
            new Product {Name = "Piłka nożna", Category="Piłka nożna", Price = 19.5m},
            new Product {Name = "Flaga narożna", Category="Piłka nożna", Price = 34.95m},
        };

        [TestMethod]
        public void TestMethod1()
        {
            Mock<IDiscounterHelper> mock = new Mock<IDiscounterHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);
            var goal = products.Sum(s => s.Price);
            var result = target.ValueProducts(products);

            Assert.AreEqual(goal, result);
        }

        private Product[] createProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_through_variable_discounts()
        {
            Mock<IDiscounterHelper> mock = new Mock<IDiscounterHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total * 0.9m));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => total - 5m);
            var target = new LinqValueCalculator(mock.Object);

            var ten = target.ValueProducts(createProduct(10));
            var hundred = target.ValueProducts(createProduct(100));
            var fifty = target.ValueProducts(createProduct(50));
            var fivehundrer = target.ValueProducts(createProduct(500));

            Assert.AreEqual(5, ten, "10 jest nieprawdiłowe");
            Assert.AreEqual(95, hundred, "100 jest nieprawdiłowe");
            Assert.AreEqual(45, fifty, "50 jest nieprawdiłowe");
            Assert.AreEqual(450, fivehundrer, "500 jest nieprawdiłowe");
            target.ValueProducts(createProduct(0));
        }
    }
}