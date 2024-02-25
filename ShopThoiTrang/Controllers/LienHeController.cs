using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class LienHeController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: LienHe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Created_At = DateTime.Now;
                contact.Updated_At = DateTime.Now;      
                if (Session["UserID"] != "")
                {
                    contact.Created_By = int.Parse(Session["UserID"].ToString());
                    contact.Updated_By = int.Parse(Session["UserID"].ToString());
                }else
                {
                    contact.Created_By = 0;
                    contact.Updated_By = 0;
                }
                contact.Status = 1;
                //
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}