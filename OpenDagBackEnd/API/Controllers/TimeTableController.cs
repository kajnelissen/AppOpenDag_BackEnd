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

namespace API.Controllers
{
    public class TimeTableController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET api/TimeTable
        public IEnumerable<TimeTable> GetTimeTables()
        {
            return db.TimeTables.AsEnumerable();
        }

        // GET api/TimeTable/5
        public TimeTable GetTimeTable(int id)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            if (timetable == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return timetable;
        }

        // PUT api/TimeTable/5
        public HttpResponseMessage PutTimeTable(int id, TimeTable timetable)
        {
            if (ModelState.IsValid && id == timetable.Id)
            {
                db.Entry(timetable).State = EntityState.Modified;

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

        // POST api/TimeTable
        public HttpResponseMessage PostTimeTable(TimeTable timetable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timetable);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, timetable);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = timetable.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/TimeTable/5
        public HttpResponseMessage DeleteTimeTable(int id)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            if (timetable == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.TimeTables.Remove(timetable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, timetable);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}