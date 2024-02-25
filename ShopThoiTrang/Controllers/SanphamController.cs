using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class SanphamController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: Sanpham
        public ActionResult Index()
        {
            var listProduct = db.Products.OrderByDescending(m => m.Created_At).ToList();
            return View(listProduct);
        }

        public ActionResult Category(string slug)
        {
            var listCat = db.Categorys.Where(m => m.Status == 1 && m.Slug == slug).OrderByDescending(m => m.Created_At).ToList();
            return View("Category",listCat);
        }

        public ActionResult ProductCategory(int catid)
        {
            var listPro = db.Products.Where(m => m.CatId == catid).OrderByDescending(m => m.Created_At).ToList();
            return View("ProductCategory",listPro);
        }

        public ActionResult ProductDetail(string slug)
        {
            var listPro = db.Products.Where(m => m.Slug == slug).OrderByDescending(m => m.Created_At).ToList();
            return View("ProductDetail", listPro);
        }

    }

}