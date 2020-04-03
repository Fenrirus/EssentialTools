namespace EssentialTools.Models
{
    using System;

    public class MinimumDiscountHelper : IDiscounterHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            if (totalParam < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (totalParam > 100)
            {
                return totalParam * 0.9m;
            }
            else if (totalParam >= 10 && totalParam <= 100)
            {
                return totalParam - 5;
            }
            else
            {
                return totalParam;
            }
        }
    }
}