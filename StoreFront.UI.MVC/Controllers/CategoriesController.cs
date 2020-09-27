﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SF.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{   [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Categories
        public ActionResult Index()
        {
            var Categories = db.Categories.Include(c => c.MainCategory);
            return View(Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category Category = db.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.MainCategoryID = new SelectList(db.MainCategories, "MainCategoryID", "MainCategoryName");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,CatDescription,MainCategoryID")] Category Category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainCategoryID = new SelectList(db.MainCategories, "MainCategoryID", "MainCategoryName", Category.MainCategoryID);
            return View(Category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category Category = db.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainCategoryID = new SelectList(db.MainCategories, "MainCategoryID", "MainCategoryName", Category.MainCategoryID);
            return View(Category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CatDescription,MainCategoryID")] Category Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainCategoryID = new SelectList(db.MainCategories, "MainCategoryID", "MainCategoryName", Category.MainCategoryID);
            return View(Category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category Category = db.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category Category = db.Categories.Find(id);
            db.Categories.Remove(Category);
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
