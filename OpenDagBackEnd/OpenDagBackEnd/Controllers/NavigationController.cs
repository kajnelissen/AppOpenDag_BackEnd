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
    public class NavigationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Navigation/

        public ActionResult Index()
        {
            return View(db.NavRoutes.ToList());
        }

        //
        // GET: /Navigation/Details/5

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
        // GET: /Navigation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Navigation/Create

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
        // GET: /Navigation/Edit/5

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
        // POST: /Navigation/Edit/5

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
        // GET: /Navigation/Delete/5

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
        // POST: /Navigation/Delete/5

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