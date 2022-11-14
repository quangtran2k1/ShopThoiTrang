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

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
