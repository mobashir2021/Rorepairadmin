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
    public class tbl_techaniciansController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_techanicians
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<technicianmodel> lst = new List<technicianmodel>();
            var tempdata = db.tbl_techanicians.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                technicianmodel model = new technicianmodel();
                if(city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);
                
            }
            return View(lst);
        }

        // GET: tbl_techanicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_techanicians tbl_techanicians = db.tbl_techanicians.Find(id);
            if (tbl_techanicians == null)
            {
                return HttpNotFound();
            }
            return View(tbl_techanicians);
        }

        // GET: tbl_techanicians/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_techanicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_techanicians tbl_techanicians, HttpPostedFileBase profileimg)
        {
            string icononepath = "";
            if (profileimg != null && profileimg.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(profileimg.FileName));
                    icononepath = profileimg.FileName;
                    profileimg.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            tbl_techanicians.technicianimage = icononepath;
            db.tbl_techanicians.Add(tbl_techanicians);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: tbl_techanicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_techanicians tbl_techanicians = db.tbl_techanicians.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_techanicians.Cityid);
            if (tbl_techanicians == null)
            {
                return HttpNotFound();
            }
            return View(tbl_techanicians);
        }

        // POST: tbl_techanicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_techanicians tbl_techanicians, HttpPostedFileBase profileimg)
        {
            string icononepath = "";
            if (profileimg != null && profileimg.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(profileimg.FileName));
                    icononepath = profileimg.FileName;
                    profileimg.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            if(icononepath != "")
            {
                tbl_techanicians.technicianimage = icononepath;
            }
            
            db.Entry(tbl_techanicians).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: tbl_techanicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_techanicians tbl_techanicians = db.tbl_techanicians.Find(id);
            if (tbl_techanicians == null)
            {
                return HttpNotFound();
            }
            return View(tbl_techanicians);
        }

        // POST: tbl_techanicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_techanicians tbl_techanicians = db.tbl_techanicians.Find(id);
            db.tbl_techanicians.Remove(tbl_techanicians);
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
