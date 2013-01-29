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
    public class NavigationController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET api/Navigation
        public IEnumerable<NavigationRoute> GetNavigationRoutes()
        {
            return db.NavRoutes.AsEnumerable();
        }

        // GET api/Navigation/5
        public NavigationRoute GetNavigationRoute(int id)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            if (navigationroute == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return navigationroute;
        }

        // PUT api/Navigation/5
        public HttpResponseMessage PutNavigationRoute(int id, NavigationRoute navigationroute)
        {
            if (ModelState.IsValid && id == navigationroute.Id)
            {
                db.Entry(navigationroute).State = EntityState.Modified;

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

        // POST api/Navigation
        public HttpResponseMessage PostNavigationRoute(NavigationRoute navigationroute)
        {
            if (ModelState.IsValid)
            {
                db.NavRoutes.Add(navigationroute);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, navigationroute);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = navigationroute.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Navigation/5
        public HttpResponseMessage DeleteNavigationRoute(int id)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            if (navigationroute == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NavRoutes.Remove(navigationroute);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, navigationroute);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}