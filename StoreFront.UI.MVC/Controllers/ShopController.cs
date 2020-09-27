using SF.DATA.EF;
using StoreFront.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShopController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities(); //dbContext
        private readonly int pageSize = 6;

        // GET: Shop
        public ActionResult Index(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();


            //Info
            var allItems = (from item in db.Products
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();


            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                allItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in allItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion

            //Build ViewModel
            foreach (var item in allItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            //Sort
            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //All Products

        public ActionResult Mens_Clothing(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var mensItems = (from item in db.Products
                             where item.CategoryID == 1
                             select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                mensItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in mensItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in mensItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Mens Clothing

        public ActionResult Womens_Clothing(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var womensItems = (from item in db.Products
                               where item.CategoryID == 2
                               select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                womensItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in womensItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in womensItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Womens Clothing

        public ActionResult Boys_Clothing(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var boysItems = (from item in db.Products
                             where item.CategoryID == 3
                             select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                boysItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in boysItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in boysItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Boys Clothing

        public ActionResult Girls_Clothing(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var girlsItems = (from item in db.Products
                              where item.CategoryID == 4
                              select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                girlsItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in girlsItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in girlsItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Girls Clothing

        public ActionResult Camping(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var campingItems = (from item in db.Products
                                where item.CategoryID == 5
                                select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                campingItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in campingItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in campingItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Camping

        public ActionResult Fishing(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var fishingItems = (from item in db.Products
                                where item.CategoryID == 6
                                select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                fishingItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in fishingItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in fishingItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Fishing

        public ActionResult Outdoor_Cooking(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var outdoorCookingItems = (from item in db.Products
                                       where item.CategoryID == 7
                                       select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                outdoorCookingItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in outdoorCookingItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in outdoorCookingItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Outdoor Cooking

        public ActionResult Backyard_Recreation(string sort, string searchString, string currentFilter, int page = 1)
        {
            List<ShopViewModel> ShopVMList = new List<ShopViewModel>();

            //Info
            var backyardRecItems = (from item in db.Products
                                       where item.CategoryID == 8
                                       select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

            ViewBag.MainCategories = db.MainCategories.Distinct().ToList();
            ViewBag.Categories = db.Categories.Distinct().ToList();

            #region Search w/ Filter
            //Search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                backyardRecItems = (from item in db.Products
                            where item.ProductName.ToLower().Contains(searchString.ToLower())
                            select new { item.ProductID, item.ProductName, item.Description, item.UnitPrice, item.ImageUrl }).ToList();

                ViewBag.CurrentFilter = searchString;

                //Build ViewModel
                foreach (var item in backyardRecItems)
                {
                    ShopViewModel objSvm = new ShopViewModel();

                    objSvm.ProductID = item.ProductID;
                    objSvm.ProductName = item.ProductName;
                    objSvm.Description = item.Description;
                    objSvm.UnitPrice = item.UnitPrice;
                    objSvm.ImageUrl = item.ImageUrl;

                    ShopVMList.Add(objSvm);
                }

                if (sort == "low-high")
                {
                    return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                if (sort == "high-low")
                {
                    return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
                }

                return View(ShopVMList.ToPagedList(page, pageSize));
            }//end search

            #endregion


            //Build ViewModel
            foreach (var item in backyardRecItems)
            {
                ShopViewModel objSvm = new ShopViewModel();

                objSvm.ProductID = item.ProductID;
                objSvm.ProductName = item.ProductName;
                objSvm.Description = item.Description;
                objSvm.UnitPrice = item.UnitPrice;
                objSvm.ImageUrl = item.ImageUrl;

                ShopVMList.Add(objSvm);
            }

            if (sort == "low-high")
            {
                return View(ShopVMList.OrderBy(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            if (sort == "high-low")
            {
                return View(ShopVMList.OrderByDescending(x => x.UnitPrice).ToPagedList(page, pageSize));
            }

            return View(ShopVMList.ToPagedList(page, pageSize));
        } //Backyard Recreation

        public ActionResult Detail(int? id)
        {
            if (TempData["PleaseAddMoreThan0"] != null)
            {
                ViewBag.PleaseAddMoreThan0 = "Please add more than 0 item(s)";
                TempData["PleaseAddMoreThan0"] = null;
            }

            if (TempData["qtyTooLarge"] != null)
            {
                ViewBag.QtyTooLarge = "Wow- That is too many items!";
                TempData["qtyTooLarge"] = null;
            }

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
        } //Product Detail

        [HttpPost]
        public ActionResult AddToCart(int productID, int qty = 1)
        {
            if (qty <= 0)
            {
                TempData["PleaseAddMoreThan0"] = "true";
                return RedirectToAction("Detail", new { id = productID });
            }

            if (qty > int.MaxValue)
            {
                TempData["qytTooLarge"] = "true";
                return RedirectToAction("Detail", new { id = productID });
            }

            Dictionary<int, ShoppingCartViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, ShoppingCartViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, ShoppingCartViewModel>();
            }

            Product product = db.Products.Where(p => p.ProductID == productID).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ShoppingCartViewModel item = new ShoppingCartViewModel(qty, product);

                if (shoppingCart.ContainsKey(product.ProductID))
                {
                    shoppingCart[product.ProductID].Qty += qty;
                }
                else
                {
                    shoppingCart.Add(product.ProductID, item);
                }

                Session["cart"] = shoppingCart;

            }

            return RedirectToAction("Index", "Cart");
        } //Add to Cart
    }

}
