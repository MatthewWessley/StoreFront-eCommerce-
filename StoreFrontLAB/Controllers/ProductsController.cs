using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFrontLAB.DATA.EF;
using PagedList;
using PagedList.Mvc;using StoreFrontLAB.Models;

namespace StoreFrontLAB.Controllers
{
    public class ProductsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        #region Add To Cart - Shopping Cart Functionality

        [HttpPost]
        public ActionResult AddToCart(int qty, int ID)
        {
            Dictionary<int, ShoppingCartViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, ShoppingCartViewModel>();
            }
            
            Product product = db.Products.Where(x => x.ID == ID).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ShoppingCartViewModel item = new ShoppingCartViewModel(qty, product);
                
                if (shoppingCart.ContainsKey(product.ID))
                {
                    shoppingCart[product.ID].Qty += qty;
                }
                else 
                {
                    shoppingCart.Add(product.ID, item);
                }

                Session["cart"] = shoppingCart;

            }
            //send to the shopping cart to view products that have been added
            return RedirectToAction("Index", "ShoppingCart");
        }

        #endregion

        // GET: Products
        [HttpGet]
        public ViewResult Index(string searchString, string currentFilter, int page = 1)
        {
            int pageSize = 5;
            var products = db.Products.OrderBy(p => p.Name).ToList();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = (from p in products
                            where p.Name.ToLower().Contains(searchString.ToLower())
                            orderby p.Name
                            select p).ToList();
            }

            ViewBag.CurrentFilter = searchString;

            return View(products.ToPagedList(page, pageSize));

        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CandyTypeID = new SelectList(db.CandyTypes, "ID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name");
            ViewBag.ProductStatusID = new SelectList(db.ProductStatuses, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,CategoryID,ManufacturerID,ProductStatusID,CandyTypeID,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandyTypeID = new SelectList(db.CandyTypes, "ID", "Name", product.CandyTypeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", product.ManufacturerID);
            ViewBag.ProductStatusID = new SelectList(db.ProductStatuses, "ID", "Name", product.ProductStatusID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandyTypeID = new SelectList(db.CandyTypes, "ID", "Name", product.CandyTypeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", product.ManufacturerID);
            ViewBag.ProductStatusID = new SelectList(db.ProductStatuses, "ID", "Name", product.ProductStatusID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,CategoryID,ManufacturerID,ProductStatusID,CandyTypeID,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandyTypeID = new SelectList(db.CandyTypes, "ID", "Name", product.CandyTypeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", product.ManufacturerID);
            ViewBag.ProductStatusID = new SelectList(db.ProductStatuses, "ID", "Name", product.ProductStatusID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
