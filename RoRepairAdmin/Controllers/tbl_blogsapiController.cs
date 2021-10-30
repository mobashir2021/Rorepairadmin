using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RoRepairAdmin.Models;

namespace RoRepairAdmin.Controllers
{
    public class tbl_blogsapiController : ApiController
    {
        private rorepairadminEntities db = new rorepairadminEntities();

        // GET: api/tbl_blogsapi
        public IQueryable<tbl_blogs> Gettbl_blogs()
        {
            return db.tbl_blogs;
        }

        // GET: api/tbl_blogsapi/5
        [ResponseType(typeof(tbl_blogs))]
        public IHttpActionResult Gettbl_blogs(int id)
        {
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            if (tbl_blogs == null)
            {
                return NotFound();
            }

            return Ok(tbl_blogs);
        }

        // PUT: api/tbl_blogsapi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_blogs(int id, tbl_blogs tbl_blogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_blogs.blogid)
            {
                return BadRequest();
            }

            db.Entry(tbl_blogs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_blogsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tbl_blogsapi
        [ResponseType(typeof(tbl_blogs))]
        public IHttpActionResult Posttbl_blogs(tbl_blogs tbl_blogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_blogs.Add(tbl_blogs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_blogs.blogid }, tbl_blogs);
        }

        // DELETE: api/tbl_blogsapi/5
        [ResponseType(typeof(tbl_blogs))]
        public IHttpActionResult Deletetbl_blogs(int id)
        {
            tbl_blogs tbl_blogs = db.tbl_blogs.Find(id);
            if (tbl_blogs == null)
            {
                return NotFound();
            }

            db.tbl_blogs.Remove(tbl_blogs);
            db.SaveChanges();

            return Ok(tbl_blogs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_blogsExists(int id)
        {
            return db.tbl_blogs.Count(e => e.blogid == id) > 0;
        }
    }
}