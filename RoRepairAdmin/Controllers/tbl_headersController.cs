using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoRepairAdmin.Models;

namespace RoRepairAdmin.Controllers
{
    public class tbl_headersController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_headers
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<headersmodel> lst = new List<headersmodel>();
            var tempdata = db.tbl_headers.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                headersmodel model = new headersmodel();
                if (city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);

            }
            return View(lst);
        }

        // GET: tbl_headers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_headers tbl_headers = db.tbl_headers.Find(id);
            if (tbl_headers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_headers);
        }

        // GET: tbl_headers/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_headers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "headerid,technicianheader,customerreviewsheader,blogheader,faqsheader,aboutrorepairheader,avgrating,totalnoofratings,Cityid")] tbl_headers tbl_headers)
        {
            if (ModelState.IsValid)
            {
                db.tbl_headers.Add(tbl_headers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_headers);
        }

        // GET: tbl_headers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            tbl_headers tbl_headers = db.tbl_headers.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_headers.Cityid);
            if (tbl_headers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_headers);
        }

        // POST: tbl_headers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "headerid,technicianheader,customerreviewsheader,blogheader,faqsheader,aboutrorepairheader,avgrating,totalnoofratings,Cityid")] tbl_headers tbl_headers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_headers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_headers);
        }

        // GET: tbl_headers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_headers tbl_headers = db.tbl_headers.Find(id);
            if (tbl_headers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_headers);
        }

        // POST: tbl_headers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_headers tbl_headers = db.tbl_headers.Find(id);
            db.tbl_headers.Remove(tbl_headers);
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
