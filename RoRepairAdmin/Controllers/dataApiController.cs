using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RoRepairAdmin.Models;
using RoRepairAdmin.common;

namespace RoRepairAdmin.Controllers
{
    [RoutePrefix("api/dataApi")]
    public class dataApiController : ApiController
    {
        rorepairadminEntities db = new rorepairadminEntities();
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage getheaders()
        {
            var lst = db.tbl_headers.First();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage gettest()
        {
            var lst = "working fine";
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage gethowitworks()
        {
            var lst = db.tbl_howitworks.First();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage gettechnicians()
        {
            var lst = db.tbl_howitworks.ToList();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage getcustomerreviews()
        {
            var lst = db.tbl_customerreviews.ToList();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage getfaqs()
        {
            var lst = db.tbl_faqs.ToList();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage getblogs()
        {
            var lst = db.tbl_blogs.ToList();
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
