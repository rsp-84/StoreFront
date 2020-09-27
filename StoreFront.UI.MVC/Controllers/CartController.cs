using StoreFront.UI.MVC.Models;
using System.Collections.Generic;

using System.Web.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count == 0)
            {
                shoppingCart = new Dictionary<int, ShoppingCartViewModel>();
                ViewBag.Message = "There are no items in your cart";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View(shoppingCart);
        }

        [HttpPost]
        public ActionResult UpdateCart(int productID, int qty = 1)
        {
            if (qty <= 0)
            {
                RemoveFromCart(productID);
                return RedirectToAction("index");
            }

            Dictionary<int, ShoppingCartViewModel> shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            shoppingCart[productID].Qty = qty;

            Session["cart"] = shoppingCart;

            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "There are no items in your cart!";
            }

            return RedirectToAction("index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            Dictionary<int, ShoppingCartViewModel> shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            shoppingCart.Remove(id);

            if (shoppingCart.Count == 0)
            {
                Session["cart"] = null;
            }

            return RedirectToAction("Index");
        }
    }
}