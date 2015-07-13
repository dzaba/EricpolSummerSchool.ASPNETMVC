using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.Controllers
{
    public class RoundController : Controller
    {
        private Contexts db = new Contexts();

        //
        // GET: /Round/

        public ActionResult Index()
        {
            return View(db.RoundModels.ToList());
        }

        //
        // GET: /Round/Details/5

        public ActionResult Details(int id = 0)
        {
            RoundModel roundmodel = db.RoundModels.Find(id);
            if (roundmodel == null)
            {
                return HttpNotFound();
            }
            return View(roundmodel);
        }

        //
        // GET: /Round/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Round/Create

        [HttpPost]
        public ActionResult Create(RoundModel roundmodel)
        {
            if (ModelState.IsValid)
            {
                db.RoundModels.Add(roundmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundmodel);
        }

        //
        // GET: /Round/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RoundModel roundmodel = db.RoundModels.Find(id);
            if (roundmodel == null)
            {
                return HttpNotFound();
            }
            return View(roundmodel);
        }

        //
        // POST: /Round/Edit/5

        [HttpPost]
        public ActionResult Edit(RoundModel roundmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundmodel);
        }

        //
        // GET: /Round/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RoundModel roundmodel = db.RoundModels.Find(id);
            if (roundmodel == null)
            {
                return HttpNotFound();
            }
            return View(roundmodel);
        }

        //
        // POST: /Round/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundModel roundmodel = db.RoundModels.Find(id);
            db.RoundModels.Remove(roundmodel);
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