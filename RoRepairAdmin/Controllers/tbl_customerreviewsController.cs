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
    public class tbl_customerreviewsController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_customerreviews
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<customerreviewmodel> lst = new List<customerreviewmodel>();
            var tempdata = db.tbl_customerreviews.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                customerreviewmodel model = new customerreviewmodel();
                if (city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);

            }
            return View(lst);
        }

        // GET: tbl_customerreviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customerreviews tbl_customerreviews = db.tbl_customerreviews.Find(id);
            if (tbl_customerreviews == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customerreviews);
        }

        // GET: tbl_customerreviews/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_customerreviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerreviewsid,technicianid,customername,rating,monthandyear,comments,Cityid")] tbl_customerreviews tbl_customerreviews)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customerreviews.Add(tbl_customerreviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_customerreviews);
        }

        // GET: tbl_customerreviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customerreviews tbl_customerreviews = db.tbl_customerreviews.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_customerreviews.Cityid);
            if (tbl_customerreviews == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customerreviews);
        }

        // POST: tbl_customerreviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerreviewsid,technicianid,customername,rating,monthandyear,comments,Cityid")] tbl_customerreviews tbl_customerreviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customerreviews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_customerreviews);
        }

        // GET: tbl_customerreviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customerreviews tbl_customerreviews = db.tbl_customerreviews.Find(id);
            if (tbl_customerreviews == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customerreviews);
        }

        // POST: tbl_customerreviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_customerreviews tbl_customerreviews = db.tbl_customerreviews.Find(id);
            db.tbl_customerreviews.Remove(tbl_customerreviews);
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
