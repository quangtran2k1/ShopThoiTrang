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
    public class PostController : BaseController
    {
        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();

        // GET: Admin/Post
        public ActionResult Index()
        {
            var list = db.Posts.Join(db.Topics, p => p.TopicId, t => t.Id, (p, t) => new PostTopic
            {
                Id = p.Id,
                TopicId = p.TopicId,
                Title = p.Title,
                Slug = p.Slug,
                Detail = p.Detail,
                Metadesc = p.Metadesc,
                Metakey = p.Metakey,
                Img = p.Img,
                Created_At = p.Created_At,
                Created_By = p.Created_By,
                Updated_At = p.Updated_At,
                Updated_By = p.Updated_By,
                Status = p.Status,
                TopicName = t.Name
            })
            .Where(m => m.Status != 0).OrderByDescending(m => m.Created_At).ToList();
            return View(list);
        }

        public ActionResult Trash()
        {
            var list = db.Posts.Join(db.Topics, p => p.TopicId, t => t.Id, (p, t) => new PostTopic
            {
                Id = p.Id,
                TopicId = p.TopicId,
                Title = p.Title,
                Slug = p.Slug,
                Detail = p.Detail,
                Metadesc = p.Metadesc,
                Metakey = p.Metakey,
                Img = p.Img,
                Created_At = p.Created_At,
                Created_By = p.Created_By,
                Updated_At = p.Updated_At,
                Updated_By = p.Updated_By,
                Status = p.Status,
                TopicName = t.Name
            }
            )
            .Where(m => m.Status == 0).OrderByDescending(m => m.Created_At).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewBag.ListTopic = new SelectList(db.Topics.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(post.Title);
                post.Slug = slug;
                post.Created_At = DateTime.Now;
                post.Created_By = int.Parse(Session["UserID"].ToString());
                post.Updated_At = DateTime.Now;
                post.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png", ".jpeg" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        post.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Post/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                //
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListTopic = new SelectList(db.Topics.ToList(), "Id", "Name", 0);
            return View(post);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListTopic = new SelectList(db.Topics.ToList(), "Id", "Name", 0);
            return View(post);
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                string slug = XString.Str_Slug(post.Title);
                post.Slug = slug;
                post.Updated_At = DateTime.Now;
                post.Updated_By = int.Parse(Session["UserID"].ToString());
                //Hình ảnh
                var Img = Request.Files["fileimg"];
                string[] FileExtention = { ".jpg", ".png" };
                if (Img.ContentLength != 0)
                {
                    if (FileExtention.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        string oldImgPath = Path.Combine(Server.MapPath("~/Public/img/Post/"), post.Img);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }

                        //Upload file
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        post.Img = imgName; //Lưu vào CSDL
                        string PathImg = Path.Combine(Server.MapPath("~/Public/img/Post/"), imgName);
                        Img.SaveAs(PathImg); //Lưu file lên server
                    }
                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Post");
            }
            ViewBag.ListTopic = new SelectList(db.Topics.ToList(), "Id", "Name", 0);
            return View(post);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Post post = db.Posts.Find(id);
            int status = (post.Status == 1) ? 2 : 1;
            post.Status = status;
            post.Updated_By = int.Parse(Session["UserID"].ToString());
            post.Updated_At = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Xóa Status = 0
        public ActionResult DelTrash(int id)
        {
            Post post = db.Posts.Find(id);
            post.Status = 0;
            post.Updated_By = int.Parse(Session["UserID"].ToString());
            post.Updated_At = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }

        //Khôi phục Status = 2
        public ActionResult Restore(int id)
        {
            Post post = db.Posts.Find(id);
            post.Status = 2;
            post.Updated_By = int.Parse(Session["UserID"].ToString());
            post.Updated_At = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Post");
        }
    }
}
