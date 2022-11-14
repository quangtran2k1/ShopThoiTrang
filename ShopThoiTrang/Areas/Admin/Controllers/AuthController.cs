using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.Error = "";
            return View("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(FormCollection field)
        {
            ViewBag.Error = "";
            string username = field["username"];
            string password = XString.ToMD5(field["password"]);
            //SELECT * FROM WHERE Roles="Admin"...
            User user = db.Users.Where(m => m.Roles == "Admin" && m.Status == 1 && (m.Username == username || m.Email == username)).FirstOrDefault();
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["UserAdmin"] = username;
                    Session["UserID"] = user.Id.ToString();
                    Session["FullName"] = user.FullName;
                    Session["Img"] = user.Img;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Error = " <p class='login-box-msg text-danger'>Mật khẩu không chính xác!</p>";
                }
            }
            else
            {
                ViewBag.Error = " <p class='login-box-msg text-danger'>Tài khoản '" + username+"' không tồn tại!</p>";
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            Session["UserID"] = "";
            Session["FullName"] = "";
            Session["Img"] = "";
            return Redirect("~/Admin/login");
        }
    }
}