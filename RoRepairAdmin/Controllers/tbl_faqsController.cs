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
    public class tbl_faqsController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_faqs
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<faqsmodel> lst = new List<faqsmodel>();
            var tempdata = db.tbl_faqs.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                faqsmodel model = new faqsmodel();
                if (city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);

            }
            return View(lst);
        }

        // GET: tbl_faqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_faqs tbl_faqs = db.tbl_faqs.Find(id);
            if (tbl_faqs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_faqs);
        }

        // GET: tbl_faqs/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_faqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "faqid,faqquestion,faqanswer,Cityid")] tbl_faqs tbl_faqs)
        {
            if (ModelState.IsValid)
            {
                db.tbl_faqs.Add(tbl_faqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_faqs);
        }

        // GET: tbl_faqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_faqs tbl_faqs = db.tbl_faqs.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_faqs.Cityid);
            if (tbl_faqs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_faqs);
        }

        // POST: tbl_faqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "faqid,faqquestion,faqanswer,Cityid")] tbl_faqs tbl_faqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_faqs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_faqs);
        }

        // GET: tbl_faqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_faqs tbl_faqs = db.tbl_faqs.Find(id);
            if (tbl_faqs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_faqs);
        }

        // POST: tbl_faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_faqs tbl_faqs = db.tbl_faqs.Find(id);
            db.tbl_faqs.Remove(tbl_faqs);
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
