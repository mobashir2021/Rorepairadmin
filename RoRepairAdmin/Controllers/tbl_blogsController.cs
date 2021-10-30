using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoRepairAdmin.Models;

namespace RoRepairAdmin.Controllers
{
    public class tbl_blogsController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_blogs
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<blogsmodel> lst = new List<blogsmodel>();
            var tempdata = db.tbl_blogs.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                blogsmodel model = new blogsmodel();
                if (city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);

            }
            return View(lst);
        }

        // GET: tbl_blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            if (tbl_blogs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blogs);
        }

        // GET: tbl_blogs/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_blogs tbl_blogs, HttpPostedFileBase blogimage, string blogdate)
        {
            string icononepath = "";
            
            if (blogimage != null && blogimage.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(blogimage.FileName));
                    icononepath = blogimage.FileName;
                    blogimage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            tbl_blogs.blogimage = icononepath;
            tbl_blogs.blogdate = blogdate;
            db.tbl_blogs.Add(tbl_blogs);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: tbl_blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_blogs.Cityid);
            if (tbl_blogs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blogs);
        }

        // POST: tbl_blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_blogs tbl_blogs, HttpPostedFileBase blogimage, string blogdate)
        {
            string icononepath = "";

            if (blogimage != null && blogimage.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(blogimage.FileName));
                    icononepath = blogimage.FileName;
                    blogimage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            if(icononepath != "")
                tbl_blogs.blogimage = icononepath;
            if(!string.IsNullOrEmpty(blogdate))
                tbl_blogs.blogdate = blogdate;
            db.Entry(tbl_blogs).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: tbl_blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            if (tbl_blogs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blogs);
        }

        // POST: tbl_blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            db.tbl_blogs.Remove(tbl_blogs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
