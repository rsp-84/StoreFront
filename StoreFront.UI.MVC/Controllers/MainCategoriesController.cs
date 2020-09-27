using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SF.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MainCategoriesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: MainCategories
        public ActionResult Index()
        {
            return View(db.MainCategories.ToList());
        }

        // GET: MainCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = db.MainCategories.Find(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // GET: MainCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainCategoryID,MainCategoryName,MainDescription")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                db.MainCategories.Add(mainCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainCategory);
        }

        // GET: MainCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = db.MainCategories.Find(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // POST: MainCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainCategoryID,MainCategoryName,MainDescription")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategory);
        }

        // GET: MainCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = db.MainCategories.Find(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // POST: MainCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainCategory mainCategory = db.MainCategories.Find(id);
            db.MainCategories.Remove(mainCategory);
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
