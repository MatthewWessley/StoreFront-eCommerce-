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
using PagedList.Mvc;

namespace StoreFrontLAB.Controllers
{
    public class ProductStatusesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: ProductStatuses
        public ActionResult Index()
        {
            return View(db.ProductStatuses.ToList());
        }

        // GET: ProductStatuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = db.ProductStatuses.Find(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // GET: ProductStatuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductStatuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] ProductStatus productStatus)
        {
            if (ModelState.IsValid)
            {
                db.ProductStatuses.Add(productStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productStatus);
        }

        // GET: ProductStatuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = db.ProductStatuses.Find(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // POST: ProductStatuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] ProductStatus productStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productStatus);
        }

        // GET: ProductStatuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = db.ProductStatuses.Find(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // POST: ProductStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStatus productStatus = db.ProductStatuses.Find(id);
            db.ProductStatuses.Remove(productStatus);
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
