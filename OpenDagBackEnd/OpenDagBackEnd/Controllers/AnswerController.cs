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
    public class AnswerController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public AnswerController() : base()
        {

        }

        //
        // GET: /Answer/

        public ActionResult Index()
        {
            var answers = db.Answers.Include(a => a.Question);
            return View(answers.ToList());
        }

        //
        // GET: /Answer/Details/5

        public ActionResult Details(int id = 0)
        {
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }

            var question = from item in db.Questions
                           where item.Id == answer.QuestionId
                           select item.Text;

            foreach(string i in question)
            {
                ViewBag.Question = i;
            }
            return View(answer);
        }

        //
        // GET: /Answer/Create

        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text");
            var studies = from item in db.Studies
                          select item;

            List<Study> allStudies = new List<Study>();
            foreach (Study s in studies)
            {
                allStudies.Add(s);
            }

            ViewBag.Studies = allStudies;

            return View();
        }

        //
        // POST: /Answer/Create

        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            var studies = from item in db.Studies
                          select item;

            List<Study> allStudies = new List<Study>();
            foreach (Study s in studies)
            {
                allStudies.Add(s);
            }

            if (ModelState.IsValid)
            {
                answer.StudyRatings = new Dictionary<Study, int>();
                for(int index = 0; index < allStudies.Count; index++)
                {
                    int value = Convert.ToInt32(Request["tbScore" + index]);
                    answer.StudyRatings.Add(db.Studies.Find(allStudies[index].Id), value);
                }
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        //
        // GET: /Answer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        public ActionResult Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        //
        // GET: /Answer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //
        // POST: /Answer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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