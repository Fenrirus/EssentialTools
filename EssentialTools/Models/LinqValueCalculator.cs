﻿namespace EssentialTools.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqValueCalculator : IvalueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}