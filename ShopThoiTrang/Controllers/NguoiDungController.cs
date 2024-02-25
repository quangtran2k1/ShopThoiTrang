using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class NguoiDungController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
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
            User user = db.Users.Where(m => m.Roles == "User" && m.Status == 1 && (m.Username == username || m.Email == username)).FirstOrDefault();
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["User"] = username;
                    Session["UserID"] = user.Id.ToString();
                    Session["Password"] = user.oldPassword;
                    Session["FullName"] = user.FullName;
                    if (user.Address != null)
                    {
                        Session["Address"] = user.Address;
                    }else
                    {
                        Session["Address"] = "";
                    }
                    Session["Img"] = user.Img;
                    Session["Phone"] = user.Phone;
                    Session["Email"] = user.Email;
                    return RedirectToAction("Index", "Trangchu");
                }
                else
                {
                    ViewBag.Error = " <p class='login-box-msg text-danger'>Mật khẩu không chính xác!</p>";
                }
            }
            else
            {
                ViewBag.Error = " <p class='login-box-msg text-danger'>Tài khoản '" + username + "' không tồn tại!</p>";
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session["User"] = "";
            Session["UserID"] = "";
            Session["Password"] = "";
            Session["FullName"] = "";
            Session["Address"] = "";
            Session["Img"] = "";
            Session["Phone"] = "";
            Session["Email"] = "";
            Session["MyCart"] = "";
            return Redirect("~/Trangchu/Index");
        }

        public ActionResult Register()
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.Where(s => s.Username == user.Username).FirstOrDefault();
                if (check == null)
                {
                    check = db.Users.Where(s => s.Email == user.Email).FirstOrDefault();
                    if (check == null)
                    {
                        if (user.rePassword == user.Password)
                        {
                            user.Password = XString.ToMD5(user.Password);
                            user.rePassword = XString.ToMD5(user.rePassword);
                            user.oldPassword = user.Password;
                            user.Roles = "User";
                            user.Img = "user-default.jpg";
                            user.Created_At = DateTime.Now;
                            user.Created_By = user.Id;
                            user.Updated_At = DateTime.Now;
                            user.Updated_By = user.Id;
                            user.Status = 1;
                            db.Users.Add(user);
                            db.SaveChanges();
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            ViewBag.Error = " <p class='login-box-msg text-danger'>Mật khẩu không khớp!</p>";
                        }
                    }
                    else
                    {
                        ViewBag.Error = " <p class='login-box-msg text-danger'>Email đã tồn tại!</p>";
                    }
                }
                else
                {
                    ViewBag.Error = " <p class='login-box-msg text-danger'>Tên đăng nhập đã tồn tại!</p>";
                }

            }
            return View();
        }

        // GET: User
        public ActionResult Index()
        {
            string user = Session["User"].ToString();
            var userList = db.Users.Where(m => m.Status == 1 && m.Username == user).ToList();
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            return View("Index", userList);
        }

        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListUser = new SelectList(db.Users.ToList(), "Id", "FullName", 0);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            if (ModelState.IsValid)
            {
                Session["Address"] = user.Address;
                string slug = XString.Str_Slug(user.FullName);
                user.Updated_At = DateTime.Now;
                user.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        string oldImgPath = Path.Combine(Server.MapPath("~/Public/img/User/"), user.Img);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }

                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        user.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/User/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListUser = new SelectList(db.Users.ToList(), "Id", "FullName", 0);
            return View(user);
        }

        public ActionResult ChangePassword(int? id)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Error = "";
            ViewBag.ListUser = new SelectList(db.Users.ToList(), "Id", "FullName", 0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(User user)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            user.oldPassword = XString.ToMD5(user.oldPassword);
            if (user.oldPassword == Session["Password"].ToString())
            {
                if (user.Password == user.rePassword)
                {
                    if (ModelState.IsValid)
                    {
                        user.Password = XString.ToMD5(user.Password);
                        user.rePassword = XString.ToMD5(user.rePassword);
                        user.oldPassword = user.Password;
                        Session["Password"] = user.oldPassword;
                        user.Updated_At = DateTime.Now;
                        user.Updated_By = int.Parse(Session["UserID"].ToString());
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Error = " <p class='login-box-msg text-danger'>Mật khẩu không khớp!</p>";
                }
            }
            else
            {
                ViewBag.Error = " <p class='login-box-msg text-danger'>Mật khẩu cũ không chính xác!</p>";
            }
            ViewBag.ListUser = new SelectList(db.Users.ToList(), "Id", "FullName", 0);
            return View("ChangePassword");
        }
    }
}