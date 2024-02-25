using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;
using System.IO;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var list = db.Products.Join(db.Categorys, p => p.CatId, c=>c.Id, (p,c)=>new ProductCategory
            {
                Id = p.Id,
                CatId = p.CatId,
                Name = p.Name,
                Slug = p.Slug,
                Detail = p.Detail,
                Metadesc = p.Metadesc,
                Metakey = p.Metakey,
                Img =p.Img,
                Number = p.Number,
                Price = p.Price,
                Pricesale = p.Pricesale,
                Created_At = p.Created_At,
                Created_By = p.Created_By,
                Updated_At = p.Updated_At,
                Updated_By = p.Updated_By,
                Status = p.Status,
                CatName = c.Name
            } 
            )
            .Where(m=>m.Status!=0).OrderByDescending(m=>m.Created_At).ToList();
            return View(list);
        }

        public ActionResult Trash()
        {
            var list = db.Products.Join(db.Categorys, p => p.CatId, c => c.Id, (p, c) => new ProductCategory
            {
                Id = p.Id,
                CatId = p.CatId,
                Name = p.Name,
                Slug = p.Slug,
                Detail = p.Detail,
                Metadesc = p.Metadesc,
                Metakey = p.Metakey,
                Img = p.Img,
                Number = p.Number,
                Price = p.Price,
                Pricesale = p.Pricesale,
                Created_At = p.Created_At,
                Created_By = p.Created_By,
                Updated_At = p.Updated_At,
                Updated_By = p.Updated_By,
                Status = p.Status,
                CatName = c.Name
            }
            )
            .Where(m => m.Status == 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(product.Name);
                product.Slug = slug;
                product.Created_At = DateTime.Now;
                product.Created_By = int.Parse(Session["UserID"].ToString());
                product.Updated_At = DateTime.Now;
                product.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png", ".jpeg"};
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        product.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Product/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                //
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Products.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(product.Name);
                product.Slug = slug;
                product.Updated_At = DateTime.Now;
                product.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        string oldImgPath = Path.Combine(Server.MapPath("~/Public/img/Product/"), product.Img);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }

                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        product.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Product/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Product product = db.Products.Find(id);
            int status = (product.Status == 1) ? 2 : 1;
            product.Status = status;
            product.Updated_By = int.Parse(Session["UserID"].ToString());
            product.Updated_At = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Xóa Status = 0
        public ActionResult DelTrash(int id)
        {
            Product product = db.Products.Find(id);
            product.Status = 0;
            product.Updated_By = int.Parse(Session["UserID"].ToString());
            product.Updated_At = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        //Khôi phục Status = 2
        public ActionResult Restore(int id)
        {
            Product product = db.Products.Find(id);
            product.Status = 2;
            product.Updated_By = int.Parse(Session["UserID"].ToString());
            product.Updated_At = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Product");
        }
    }
}
