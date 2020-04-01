namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public IEnumerable<Product> Products { get; set; }
        private IvalueCalculator calc;

        public ShoppingCart(IvalueCalculator calcParam)
        {
            calc = calcParam;
        }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}