using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var listMess = db.Contacts.Where(m => m.Status != 0 && m.Title != "Đăng ký nhận thông báo").OrderByDescending(m => m.Created_At).Take(5).ToList();
            var listSub = db.Contacts.Where(m => m.Status != 0 && m.Title == "Đăng ký nhận thông báo").OrderByDescending(m => m.Created_At).Take(5).ToList();
            ViewBag.ListMess = listMess;
            ViewBag.ListSub = listSub;
            return View();
        }
    }
}