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
    public class PlayerController : Controller
    {
        private PlayerModel.PlayerDBContext db = new PlayerModel.PlayerDBContext();

        //
        // GET: /Players/

        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        //
        // GET: /Players/Details/5

        public ActionResult Details(int id = 0)
        {
            PlayerModel playermodel = db.Players.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // GET: /Players/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Players/Create

        [HttpPost]
        public ActionResult Create(PlayerModel playermodel)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(playermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playermodel);
        }

        //
        // GET: /Players/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlayerModel playermodel = db.Players.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        public ActionResult Edit(PlayerModel playermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playermodel);
        }

        //
        // GET: /Players/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlayerModel playermodel = db.Players.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerModel playermodel = db.Players.Find(id);
            db.Players.Remove(playermodel);
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