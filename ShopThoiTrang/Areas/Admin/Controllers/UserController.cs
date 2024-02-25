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
    public class UserController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/User
        public ActionResult Index()
        {
            var list = db.Users.Where(m => m.Status != 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Index", list);
        }

        public ActionResult Trash()
        {
            var list = db.Users.Where(m => m.Status == 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Trash", list);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            list.Add(new SelectListItem { Text = "User", Value = "User" });
            ViewBag.DropList = new SelectList(list, "Value", "Text");
            return View(user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                user.Updated_At = DateTime.Now;
                user.Updated_By = int.Parse(Session["UserID"].ToString());
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            list.Add(new SelectListItem { Text = "User", Value = "User" });
            ViewBag.DropList = new SelectList(list, "Value", "Text");
            return View(user);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Trash", "User");
        }

        //Thay đổi trạng thái
        public ActionResult Status(int id)
        {
            User user = db.Users.Find(id);
            int status = (user.Status == 1) ? 2 : 1;
            user.Status = status;
            user.Updated_By = int.Parse(Session["UserID"].ToString());
            user.Updated_At = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Xóa Status = 0
        public ActionResult DelTrash(int id)
        {
            User user = db.Users.Find(id);
            user.Status = 0;
            user.Updated_By = int.Parse(Session["UserID"].ToString());
            user.Updated_At = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        //Khôi phục Status = 2
        public ActionResult Restore(int id)
        {
            User user = db.Users.Find(id);
            user.Status = 2;
            user.Updated_By = int.Parse(Session["UserID"].ToString());
            user.Updated_At = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "User");
        }
    }
}
