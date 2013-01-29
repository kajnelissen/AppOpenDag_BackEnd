using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using OpenDagBackEnd.Models;

namespace OpenDagBackEnd.Controllers.api
{
    public class StudyController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET api/Study
        public IEnumerable<Study> GetStudies()
        {
            return db.Studies.AsEnumerable();
        }

        // GET api/Study/5
        public Study GetStudy(int id)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return study;
        }

        // PUT api/Study/5
        public HttpResponseMessage PutStudy(int id, Study study)
        {
            if (ModelState.IsValid && id == study.Id)
            {
                db.Entry(study).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Study
        public HttpResponseMessage PostStudy(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Studies.Add(study);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, study);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = study.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Study/5
        public HttpResponseMessage DeleteStudy(int id)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Studies.Remove(study);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, study);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}