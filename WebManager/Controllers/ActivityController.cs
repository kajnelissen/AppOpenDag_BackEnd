using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebManager.Model;
using WebManager.Data;

namespace WebManager.Controllers
{
    public class ActivityController : Controller
    {
        private EFUnitOfWork db = new EFUnitOfWork();

        //
        // GET: /Activity/

        public ActionResult Index()
        {
            return View(db.TimeTableEntries.GetAll());
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.GetById(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            ViewBag.TimeTableId = new SelectList(db.TimeTables.GetAll(), "Id", "Id");
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(TimeTableEntry timetableentry)
        {
            if (ModelState.IsValid)
            {
                db.TimeTableEntries.Add(timetableentry);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(timetableentry);
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.GetById(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeTableId = new SelectList(db.TimeTableEntries.GetAll(), "Id", "Title", timetableentry.Id);
            return View(timetableentry);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeTableEntry timetableentry)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(timetableentry).State = EntityState.Modified;
                db.TimeTableEntries.GetById(timetableentry.Id).EndTime = timetableentry.EndTime;
                db.TimeTableEntries.GetById(timetableentry.Id).Description = timetableentry.Description;
                db.TimeTableEntries.GetById(timetableentry.Id).Location = timetableentry.Location;
                db.TimeTableEntries.GetById(timetableentry.Id).StartTime = timetableentry.StartTime;
                db.TimeTableEntries.GetById(timetableentry.Id).TimeTable = timetableentry.TimeTable;
                db.TimeTableEntries.GetById(timetableentry.Id).TimeTableId = timetableentry.TimeTableId;
                db.TimeTableEntries.GetById(timetableentry.Id).Title = timetableentry.Title;
                db.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.TimeTableId = new SelectList(db.TimeTables, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.GetById(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.GetById(id);
            db.TimeTableEntries.Remove(timetableentry);
            db.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}