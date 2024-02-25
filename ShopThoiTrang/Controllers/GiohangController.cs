using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class GiohangController : Controller
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        XCart xcart = new XCart();
        // GET: Giohang
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            List<CartItem> listcart = xcart.GetCart();
            return View("Index",listcart);
        }

        public ActionResult Add(int id)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }else
            {
                Product product = db.Products.Find(id);
                CartItem cartitem = new CartItem(product.Id, product.Name, product.Img, product.Price, 1);
                List<CartItem> listcart = xcart.Add(cartitem, id);
            }
            return RedirectToAction("Index","Giohang");
        }

        public ActionResult Del(int id)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }else
            {
                xcart.DelCart(id);
            }
            return RedirectToAction("Index", "Giohang");
        }

        public ActionResult Update(FormCollection form)
        {
            var test = "";
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            else
            {
                if (!string.IsNullOrEmpty(form["update"]))
                {
                    var listqty = form["qty"];
                    test = listqty;
                    var listarr = listqty.Split(',');
                    xcart.UpdateCart(listarr);
                }
            }
        
            return RedirectToAction("Index", "Giohang");
        }

        public ActionResult Thanhtoan()
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            int id = int.Parse(Session["UserID"].ToString());
            if (System.Web.HttpContext.Current.Session["Address"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/edit/" + Session["UserID"]);
            }
            User user = db.Users.Find(id);
            ViewBag.user = user;
            List<CartItem> listcart = xcart.GetCart();
            return View("Thanhtoan", listcart);
        }

        public ActionResult Dathang(FormCollection field)
        {
            if (System.Web.HttpContext.Current.Session["User"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/user/login");
            }
            int userid = int.Parse(Session["UserID"].ToString());
            User user = db.Users.Find(userid);
            String note = field["Note"];
            Order order = new Order();
            order.UserId = userid;
            order.Name = user.FullName;
            order.Phone = user.Phone;
            order.Email = user.Email;
            order.Note = note;
            order.Created_At = DateTime.Now;
            order.Updated_At = DateTime.Now;
            order.Updated_By = userid;
            order.Status = 1;
            db.Orders.Add(order);
            if (db.SaveChanges() == 1)
            {
                List<CartItem> listcart = xcart.GetCart();
                foreach(CartItem cartitem in listcart)
                {
                    OrderDetail orderdetail = new OrderDetail();
                    orderdetail.OrderId = order.Id;
                    orderdetail.ProductId = cartitem.Id;
                    orderdetail.Price = cartitem.Price;
                    orderdetail.Qty = cartitem.Qty;
                    orderdetail.Amount = cartitem.Amount;
                    db.OrderDetails.Add(orderdetail);
                    db.SaveChanges();
                }
            }
            Session["MyCart"] = "";
            return Redirect("~/cart");
        }

        public ActionResult HuyDon(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return Redirect("~/user");
        }
    }
}