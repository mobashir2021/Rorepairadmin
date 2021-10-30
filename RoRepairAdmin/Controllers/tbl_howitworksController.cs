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
    public class tbl_howitworksController : Controller
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: tbl_howitworks
        public ActionResult Index()
        {
            List<City> citylist = db.Cities.ToList();
            List<howitworksmodel> lst = new List<howitworksmodel>();
            var tempdata = db.tbl_howitworks.ToList();
            foreach (var data in tempdata)
            {
                City city = citylist.Where(x => x.Cityid == data.Cityid).FirstOrDefault();
                howitworksmodel model = new howitworksmodel();
                if (city != null)
                {
                    model.City = city.Cityname;
                }
                model.tbl = data;
                lst.Add(model);

            }
            return View(lst);
        }

        // GET: tbl_howitworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_howitworks tbl_howitworks = db.tbl_howitworks.Find(id);
            if (tbl_howitworks == null)
            {
                return HttpNotFound();
            }
            return View(tbl_howitworks);
        }

        // GET: tbl_howitworks/Create
        public ActionResult Create()
        {
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname");
            return View();
        }

        // POST: tbl_howitworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_howitworks tbl_howitworks, HttpPostedFileBase iconone, HttpPostedFileBase icontwo, HttpPostedFileBase iconthree, HttpPostedFileBase iconfour)
        {
            if (ModelState.IsValid)
            {
                string icononepath = "";
                string icontwopath = "";
                string iconthreepath = "";
                string iconfourpath = "";
                if (iconone != null && iconone.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                                   Path.GetFileName(iconone.FileName));
                        icononepath = iconone.FileName;
                        iconone.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }

                if (icontwo != null && icontwo.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                                   Path.GetFileName(icontwo.FileName));
                        icontwopath = icontwo.FileName;
                        icontwo.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }

                if (iconthree != null && iconthree.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                                   Path.GetFileName(iconthree.FileName));
                        iconthreepath = iconthree.FileName;
                        iconthree.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }

                if (iconfour != null && iconfour.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                                   Path.GetFileName(iconfour.FileName));
                        iconfourpath = iconfour.FileName;
                        iconfour.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                tbl_howitworks.howitworksiconone = icononepath;
                tbl_howitworks.howitworksicontwo = icontwopath;
                tbl_howitworks.howitworksiconthree = iconthreepath;
                tbl_howitworks.howitworksiconfour = iconfourpath;

                db.tbl_howitworks.Add(tbl_howitworks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_howitworks);
        }

        // GET: tbl_howitworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_howitworks tbl_howitworks = db.tbl_howitworks.Find(id);
            List<City> citylist = db.Cities.ToList();
            ViewBag.CityList = new SelectList(citylist, "Cityid", "Cityname", tbl_howitworks.Cityid);
            if (tbl_howitworks == null)
            {
                return HttpNotFound();
            }
            return View(tbl_howitworks);
        }

        // POST: tbl_howitworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_howitworks tbl_howitworks, HttpPostedFileBase iconone, HttpPostedFileBase icontwo, HttpPostedFileBase iconthree, HttpPostedFileBase iconfour)
        {
            string icononepath = "";
            string icontwopath = "";
            string iconthreepath = "";
            string iconfourpath = "";
            if (iconone != null && iconone.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(iconone.FileName));
                    icononepath = iconone.FileName;
                    iconone.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }

            if (icontwo != null && icontwo.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(icontwo.FileName));
                    icontwopath = icontwo.FileName;
                    icontwo.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }

            if (iconthree != null && iconthree.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(iconthree.FileName));
                    iconthreepath = iconthree.FileName;
                    iconthree.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }

            if (iconfour != null && iconfour.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                                               Path.GetFileName(iconfour.FileName));
                    iconfourpath = iconfour.FileName;
                    iconfour.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            if(icononepath != "")
            {
                tbl_howitworks.howitworksiconone = icononepath;
            }

            if (icontwopath != "")
            {
                tbl_howitworks.howitworksicontwo = icontwopath;
            }

            if (iconthreepath != "")
            {
                tbl_howitworks.howitworksiconthree = iconthreepath;
            }
            if (iconfourpath != "")
            {
                tbl_howitworks.howitworksiconfour = iconfourpath;
            }

            
            
            
            db.Entry(tbl_howitworks).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: tbl_howitworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_howitworks tbl_howitworks = db.tbl_howitworks.Find(id);
            if (tbl_howitworks == null)
            {
                return HttpNotFound();
            }
            return View(tbl_howitworks);
        }

        // POST: tbl_howitworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_howitworks tbl_howitworks = db.tbl_howitworks.Find(id);
            db.tbl_howitworks.Remove(tbl_howitworks);
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
