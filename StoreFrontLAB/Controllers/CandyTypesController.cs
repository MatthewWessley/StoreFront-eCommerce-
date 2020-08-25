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
    public class CandyTypesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        [HttpGet]
        public ViewResult Index(int page = 1)
        {
            int pageSize = 5;

            var candytypes = db.CandyTypes.OrderBy(t => t.Name).ToList();
            return View(candytypes.ToPagedList(page, pageSize));

        }

        // GET: CandyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandyType candyType = db.CandyTypes.Find(id);
            if (candyType == null)
            {
                return HttpNotFound();
            }
            return View(candyType);
        }

        // GET: CandyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] CandyType candyType)
        {
            if (ModelState.IsValid)
            {
                db.CandyTypes.Add(candyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candyType);
        }

        // GET: CandyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandyType candyType = db.CandyTypes.Find(id);
            if (candyType == null)
            {
                return HttpNotFound();
            }
            return View(candyType);
        }

        // POST: CandyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] CandyType candyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candyType);
        }

        // GET: CandyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandyType candyType = db.CandyTypes.Find(id);
            if (candyType == null)
            {
                return HttpNotFound();
            }
            return View(candyType);
        }

        // POST: CandyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandyType candyType = db.CandyTypes.Find(id);
            db.CandyTypes.Remove(candyType);
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
