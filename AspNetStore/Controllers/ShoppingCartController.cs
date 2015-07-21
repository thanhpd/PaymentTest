using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspNetStore.Models;
using AspNetStore.Services;

namespace AspNetStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public async ActionResult Index()
        {
            var cart = new ShoppingCart(HttpContext);
            var items = await cart.GetCartItemsAsync();

            return View(new ShoppingCartViewModel
            {
                Items = items,
                Total = CalculateCart(items)
            });
        }

        public async Task<ActionResult> AddToCart(int id)
        {
            var cart = new ShoppingCart(HttpContext);

            await cart.AddAsync(id);

            return RedirectToAction("index");
        }

        public async Task<ActionResult> RemoveFromCart(int id)
        {
            var cart = new ShoppingCart(HttpContext);

            await cart.RemoveAsync(id);

            return RedirectToAction("index");
        }

        public  async Task<IEnumerable<CartItem>

        private static decimal CalculateCart(IEnumerable<CartItem> items )
        {
            var total = items.Sum(item => (item.product.Price*item.Count));
        }
    }
}