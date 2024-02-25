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
    public class SliderController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/Slider
        public ActionResult Index()
        {
            var list = db.Sliders.Where(m => m.Status != 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Index", list);
        }

        public ActionResult Trash()
        {
            var list = db.Sliders.Where(m => m.Status == 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListSlider = new SelectList(db.Sliders.ToList(), "Orders", "Name", 0);
            return View(slider);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            ViewBag.ListSlider = new SelectList(db.Sliders.ToList(), "Orders", "Name", 0);
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(slider.Name);
                slider.Created_At = DateTime.Now;
                slider.Created_By = int.Parse(Session["UserID"].ToString());
                slider.Updated_At = DateTime.Now;
                slider.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png", ".jpeg" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        slider.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Slider/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListSlider = new SelectList(db.Sliders.ToList(), "Orders", "Name", 0);
            return View(slider);
        }

        // GET: Admin/Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListSlider = new SelectList(db.Sliders.ToList(), "Orders", "Name", 0);
            return View(slider);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(slider.Name);
                slider.Updated_At = DateTime.Now;
                slider.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        string oldImgPath = Path.Combine(Server.MapPath("~/Public/img/Slider/"), slider.Img);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }

                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        slider.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Slider/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Slider");
            }
            ViewBag.ListSlider = new SelectList(db.Sliders.ToList(), "Orders", "Name", 0);
            return View(slider);
        }

        // GET: Admin/Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Trash", "Slider");
        }

        //Thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Slider slider = db.Sliders.Find(id);
            int status = (slider.Status == 1) ? 2 : 1;
            slider.Status = status;
            slider.Updated_By = int.Parse(Session["UserID"].ToString());
            slider.Updated_At = DateTime.Now;
            db.Entry(slider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Xóa Status = 0
        public ActionResult DelTrash(int id)
        {
            Slider slider = db.Sliders.Find(id);
            slider.Status = 0;
            slider.Updated_By = int.Parse(Session["UserID"].ToString());
            slider.Updated_At = DateTime.Now;
            db.Entry(slider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Slider");
        }

        //Khôi phục Status = 2
        public ActionResult Restore(int id)
        {
            Slider slider = db.Sliders.Find(id);
            slider.Status = 2;
            slider.Updated_By = int.Parse(Session["UserID"].ToString());
            slider.Updated_At = DateTime.Now;
            db.Entry(slider).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Slider");
        }
    }
}
