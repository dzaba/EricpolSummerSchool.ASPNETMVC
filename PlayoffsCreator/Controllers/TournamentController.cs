using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.Controllers
{
    public class TournamentController : Controller
    {
        //
        // GET: /Tournament/

        public ActionResult Index()
        {
            List<GameModel> games = new List<GameModel>();


            return View(games);
        }

    }
}
