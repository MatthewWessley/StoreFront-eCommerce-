using StoreFrontLAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFrontLAB.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            //Create alocal version of the shopping cart from the Session(global) version
            //If the value is null or the count is 0 create ab empty instance and provide no cart items
            var shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count == 0)
            {
                //new empty instance of the local shopping cart to pass to the view
                //(strongly typed view MUST have an instance of our shopping cart in order to load)
                shoppingCart = new Dictionary<int, ShoppingCartViewModel>();
                ViewBag.Message = "There is no candy in your cart.";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View(shoppingCart);
        }

        public ActionResult UpdateCart(int ID, int qty)
        {
            //retrieve the cart from session and assign it to our local dictionary
            Dictionary<int, ShoppingCartViewModel> shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            //Update the qty in the local storage
            shoppingCart[ID].Qty = qty;

            //return the local cart to session
            Session["cart"] = shoppingCart;

            //logic to display a message if they update to NO items in their cart
            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "There is no candy in your cart.";
            }

            //return View("Index") - the code in the Index action WILL NOT run - the cart totals will not change. In fact, it may cause an error because no shoppingCart (Dictionary) was sent to the View

            //RedirectToAction to the Index so that the code runs in that method and returns the view with the updated data.
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            //retrieve the cart from session and assign it to our local dictionary
            Dictionary<int, ShoppingCartViewModel> shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];

            //call the remove method from the dictionary class
            shoppingCart.Remove(id);

            //set up viewbag message for no results
            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "There is no candy in your cart.";
                Session["cart"] = null;
            }

            return RedirectToAction("Index");

        }
    }
}
