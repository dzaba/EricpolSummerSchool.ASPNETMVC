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
        private Contexts db = new Contexts();
        private string dropdownListDefault = "No team in DB";
        //
        // GET: /Player/

        public ActionResult Index()
        {
            return View(db.PlayerModels.ToList());
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(int id = 0)
        {
            PlayerModel playermodel = db.PlayerModels.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {
            ViewBag.TeamNameList = GetTeamNamesList();
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
        public ActionResult Create(PlayerModel playermodel)
        {
            if (ModelState.IsValid) 
            { 
                db.PlayerModels.Add(playermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamNameList = GetTeamNamesList();
            return View(playermodel);
        }

        //
        // GET: /Player/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlayerModel playermodel = db.PlayerModels.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // POST: /Player/Edit/5

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
        // GET: /Player/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlayerModel playermodel = db.PlayerModels.Find(id);
            if (playermodel == null)
            {
                return HttpNotFound();
            }
            return View(playermodel);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerModel playermodel = db.PlayerModels.Find(id);
            db.PlayerModels.Remove(playermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private SelectList GetTeamNamesList()
        {
            List<string> teamNames = new List<string>();
            //teamNames.Add("No team selected");
            if (db.Teams.Count() == 0)
                teamNames.Add(dropdownListDefault);

            foreach (var team in db.Teams)
            {
                teamNames.Add(team.TeamName);
            }
            return new SelectList(teamNames.ToArray());
        }
    }
}