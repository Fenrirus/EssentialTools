namespace EssentialTools.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqValueCalculator : IvalueCalculator
    {
        private readonly IDiscounterHelper _discounter;
        private static int counter = 0;

        public LinqValueCalculator(IDiscounterHelper discounter)
        {
            _discounter = discounter;
            System.Diagnostics.Debug.WriteLine(string.Format("Utworzono egzemplarz {0}", ++counter));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}