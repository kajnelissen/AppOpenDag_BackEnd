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
    public class NavigationTrackController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /NavigationTrack/

        public ActionResult Index()
        {
            var navigationtracks = db.NavigationTracks.Include(n => n.Route);
            return View(navigationtracks.ToList());
        }

        //
        // GET: /NavigationTrack/Details/5

        public ActionResult Details(int id = 0)
        {
            NavigationTrack navigationtrack = db.NavigationTracks.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Create

        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.NavRoutes, "Id", "Name");
            return View();
        }

        //
        // POST: /NavigationTrack/Create

        [HttpPost]
        public ActionResult Create(NavigationTrack navigationtrack, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);

                navigationtrack.Image = fileBytes;

                db.NavigationTracks.Add(navigationtrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.NavRoutes, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NavigationTrack navigationtrack = db.NavigationTracks.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.NavRoutes, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // POST: /NavigationTrack/Edit/5

        [HttpPost]
        public ActionResult Edit(NavigationTrack navigationtrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navigationtrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.NavRoutes, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NavigationTrack navigationtrack = db.NavigationTracks.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            return View(navigationtrack);
        }

        //
        // POST: /NavigationTrack/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NavigationTrack navigationtrack = db.NavigationTracks.Find(id);
            db.NavigationTracks.Remove(navigationtrack);
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