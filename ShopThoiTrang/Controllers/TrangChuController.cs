using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class TrangChuController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: TrangChu
        public ActionResult Index()
        {
            var listcat = db.Categorys.Where(m => m.Status == 1 && m.ParentId == 0).ToList();
            return View(listcat);
        }

        public ActionResult Search(string key)
        {
                var listSP = db.Products.Where(m => m.Status == 1 && (m.Name.Contains(key) || m.Metadesc.Contains(key) || m.Metakey.Contains(key) || m.Detail.Contains(key))).OrderByDescending(m => m.Name);
                return View("Search", listSP);
        }

    }
}