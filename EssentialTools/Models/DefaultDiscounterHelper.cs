using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class DefaultDiscounterHelper : IDiscounterHelper
    {
        private decimal discountSize { get; set; }

        public DefaultDiscounterHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }
}