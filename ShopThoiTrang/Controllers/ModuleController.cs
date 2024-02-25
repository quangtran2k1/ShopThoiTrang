using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class ModuleController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: Module
        public ActionResult Menu()
        {
            return View("Menu");
        }

        public ActionResult SidebarMenu()
        {
            var listcat = db.Categorys.Where(m => m.Status == 1 && m.ParentId == 0).ToList();
            ViewBag.listCat = listcat;
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Slider()
        {
            var listSlider = db.Sliders.Where(m => m.Status != 0).OrderByDescending(m => m.Updated_At).ToList();
            ViewBag.Slider = listSlider;
            return View();
        }

        public ActionResult Modal()
        {
            var modal = db.Sliders.Where(m => m.Status == 1).OrderByDescending(m => m.Created_At).Take(1).ToList();
            ViewBag.Modal = modal;
            return View();
        }
    }
}