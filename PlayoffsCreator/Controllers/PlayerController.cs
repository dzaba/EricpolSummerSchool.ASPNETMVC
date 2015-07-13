using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayoffsCreator.Models;
using PlayoffsCreator.BusinessLogic;

namespace PlayoffsCreator.Controllers
{
    public class PlayerController : Controller
    {
        public PlayerController()
        {
        }

        public ActionResult Index()
        {
            return View(PlayersList.Players);
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
        public ActionResult Create(PlayerModel playerModel)
        {
            try
            {
                // TODO: Add insert logic here
                PlayersList.Players.Add(playerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Player/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Player/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Player/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                PlayersList.Players.RemoveAll(item => item.ID == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
