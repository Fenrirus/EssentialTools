namespace EssentialTools.Controllers
{
    using EssentialTools.Models;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IvalueCalculator calc;

        private Product[] products = {
            new Product {Name = "Kajak", Category="Sporty Wodne", Price = 275m},
            new Product {Name = "Kamizelka ratunkowa", Category="Sporty Wodne", Price = 48.95m},
            new Product {Name = "Piłka nożna", Category="Piłka nożna", Price = 19.5m},
            new Product {Name = "Flaga narożna", Category="Piłka nożna", Price = 34.95m},
        };

        public HomeController(IvalueCalculator calcParam, IvalueCalculator calc2)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            var cart = new ShoppingCart(calc) { Products = products };
            decimal? totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}