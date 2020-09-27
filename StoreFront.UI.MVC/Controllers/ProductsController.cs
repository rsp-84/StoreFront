using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC3.UI.MVC.Utilities;
using SF.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();
        private readonly string[] goodExts = { ".jpeg", ".jpg", ".gif", ".png" }; //for file upload
        private readonly int maxFileSize = 4194304; //for max file upload size by ASP.NET


        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(products.ToList());
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
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,ImageUrl,IsActive, Description")] Product product, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                #region File Upload w/ ImageService
                string imgName = "noImgage.png";
                if (img != null)
                {
                    imgName = img.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf("."));

                    if (goodExts.Contains(ext.ToLower()) && (img.ContentLength <= maxFileSize) )
                    {
                        imgName = Guid.NewGuid() + ext.ToLower();

                        string savePath = Server.MapPath("~/content/img/");

                        Image convertedImage = Image.FromStream(img.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 280;

                        ImageService.ResizeImage(savePath, imgName, convertedImage, maxImageSize, maxThumbSize);
                    }
                    else
                    {
                        imgName = "noImage.png";
                    }

                }

                product.ImageUrl = imgName;

                #endregion

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
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
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,ImageUrl,IsActive, Description")] Product product, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                #region File Upload w/ ImageService

                if (img != null)
                {
                    string imgName = img.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf("."));

                    if (goodExts.Contains(ext.ToLower()) && (img.ContentLength <= maxFileSize) )
                    {
                        imgName = Guid.NewGuid() + ext.ToLower();

                        string savePath = Server.MapPath("~/content/img/");

                        Image convetedImage = Image.FromStream(img.InputStream);

                        int maxImgSize = 500;

                        int maxThumbSize = 280;

                        ImageService.ResizeImage(savePath, imgName, convetedImage, maxImgSize, maxThumbSize);

                        ImageService.Delete(savePath, product.ImageUrl);

                        product.ImageUrl = imgName;
                    }
                }


                #endregion

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
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

            ImageService.Delete(Server.MapPath("~/Content/img/"), product.ImageUrl);

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
