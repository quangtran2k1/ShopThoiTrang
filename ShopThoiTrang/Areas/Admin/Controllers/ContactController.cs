using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            var list = db.Contacts.Where(m => m.Status != 0 && m.Title != "Đăng ký nhận thông báo").OrderByDescending(m => m.Created_At).ToList();
            return View("Index", list);
        }

        public ActionResult Subscribe()
        {
            var list = db.Contacts.Where(m => m.Status != 0 && m.Title == "Đăng ký nhận thông báo").OrderByDescending(m => m.Created_At).ToList();
            return View("Subscribe", list);
        }

        // GET: Admin/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = db.Contacts.Where(m => m.Id == id).OrderByDescending(m => m.Created_At).ToList();
            return View("Details", list);
        }
    }
}
