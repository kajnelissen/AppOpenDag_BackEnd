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
    public class SurveyController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET api/Survey
        public IEnumerable<Survey> GetSurveys()
        {
            return db.Surveys.AsEnumerable();
        }

        // GET api/Survey/5
        public Survey GetSurvey(int id)
        {
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return survey;
        }

        // PUT api/Survey/5
        public HttpResponseMessage PutSurvey(int id, Survey survey)
        {
            if (ModelState.IsValid && id == survey.Id)
            {
                db.Entry(survey).State = EntityState.Modified;

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

        // POST api/Survey
        public HttpResponseMessage PostSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, survey);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = survey.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Survey/5
        public HttpResponseMessage DeleteSurvey(int id)
        {
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Surveys.Remove(survey);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, survey);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}