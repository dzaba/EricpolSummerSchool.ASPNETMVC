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
    public class TeamController : Controller
    {
        private Contexts db = new Contexts();

        //
        // GET: /Team/

        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        //
        // GET: /Team/Details/5

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            List<PlayerModel> playerList = GetAllPlayersInTeamById(teamModel);
            ViewBag.TeamName = teamModel.TeamName;
            return View("../Player/FindAllPlayersByTeamId",playerList);
        }

        private List<PlayerModel> GetAllPlayersInTeamById(TeamModel teammodel)
        {
            return (from player in db.PlayerModels
                where player.TeamName == teammodel.TeamName
                select player).ToList();
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Team/Create

        [HttpPost]
        public ActionResult Create(TeamModel teammodel)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teammodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teammodel);
        }

        //
        // GET: /Team/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TeamModel teammodel = db.Teams.Find(id);
            if (teammodel == null)
            {
                return HttpNotFound();
            }
            return View(teammodel);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        public ActionResult Edit(TeamModel teammodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teammodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teammodel);
        }

        //
        // GET: /Team/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TeamModel teammodel = db.Teams.Find(id);
            if (teammodel == null)
            {
                return HttpNotFound();
            }
            return View(teammodel);
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamModel teammodel = db.Teams.Find(id);
            db.Teams.Remove(teammodel);
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