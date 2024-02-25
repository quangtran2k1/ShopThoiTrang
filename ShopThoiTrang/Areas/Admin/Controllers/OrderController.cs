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
    public class OrderController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var list = db.Orders.Join(db.Users, o => o.UserId, u => u.Id, (o, u)=>new OrderUser
            {
                Id = o.Id,
                UserId = o.UserId,
                Name = o.Name,
                Phone = o.Phone,
                Email = o.Email,
                Note = o.Note,
                Created_At = o.Created_At,
                Updated_By = o.Updated_By,
                Updated_At = o.Updated_At,
                Status = o.Status,
                Addr = u.Address
            }
            )
            .Where(m => m.Status != 0).OrderByDescending(m => m.Created_At).ToList();
            return View(list);
        }

        public ActionResult Trash()
        {
            var list = db.Orders.Join(db.Users, o => o.UserId, u => u.Id, (o, u) => new OrderUser
            {
                Id = o.Id,
                UserId = o.UserId,
                Name = o.Name,
                Phone = o.Phone,
                Email = o.Email,
                Note = o.Note,
                Created_At = o.Created_At,
                Updated_By = o.Updated_By,
                Updated_At = o.Updated_At,
                Status = o.Status,
                Addr = u.Address
            }
            )
            .Where(m => m.Status == 0).OrderByDescending(m => m.Created_At).ToList();
            return View(list);
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = db.OrderDetails.Join(db.Products, odt => odt.ProductId, p => p.Id, (odt, p) => new OrderDetailLink
                {
                    Id = odt.Id,
                    OrderId = odt.OrderId,
                    ProductId = odt.ProductId,
                    Price = odt.Price,
                    Qty = odt.Qty,
                    Amount = odt.Amount,
                    ProductName = p.Name,
                    ProductImg = p.Img
                }).Where(m=>m.OrderId == id).OrderByDescending(m=>m.Id).ToList();

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        //Thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Order order = db.Orders.Find(id);
            int status = (order.Status == 1) ? 2 : 1;
            order.Status = status;
            order.Updated_By = int.Parse(Session["UserID"].ToString());
            order.Updated_At = DateTime.Now;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Xóa Status = 0
        public ActionResult DelTrash(int id)
        {
            Order order = db.Orders.Find(id);
            order.Status = 0;
            order.Updated_By = int.Parse(Session["UserID"].ToString());
            order.Updated_At = DateTime.Now;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Order");
        }

        //Khôi phục Status = 2
        public ActionResult Restore(int id)
        {
            Order order = db.Orders.Find(id);
            order.Status = 2;
            order.Updated_By = int.Parse(Session["UserID"].ToString());
            order.Updated_At = DateTime.Now;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Order");
        }
    }
}
