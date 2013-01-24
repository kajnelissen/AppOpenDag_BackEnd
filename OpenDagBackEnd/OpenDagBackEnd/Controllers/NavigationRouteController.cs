using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenDagBackEnd.Models;

namespace OpenDagBackEnd.Controllers
{
    public class NavigationRouteController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /NavigationRoute/

        public ActionResult Index()
        {
            return View(db.NavRoutes.ToList());
        }

        //
        // GET: /NavigationRoute/Details/5

        public ActionResult Details(int id = 0)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NavigationRoute/Create

        [HttpPost]
        public ActionResult Create(NavigationRoute navigationroute)
        {
            if (ModelState.IsValid)
            {
                db.NavRoutes.Add(navigationroute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // POST: /NavigationRoute/Edit/5

        [HttpPost]
        public ActionResult Edit(NavigationRoute navigationroute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navigationroute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // POST: /NavigationRoute/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NavigationRoute navigationroute = db.NavRoutes.Find(id);
            db.NavRoutes.Remove(navigationroute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}