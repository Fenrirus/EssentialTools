namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public interface IvalueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}