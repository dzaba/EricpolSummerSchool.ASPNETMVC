using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using PlayoffsCreator.Models;

namespace PlayoffsCreator.Controllers.Api
{
    public class TournamentController : ApiController
    {
        [HttpGet]
        public Tournament GetTournament()
        {
            Tournament tournament = new Tournament() { GamesList = new List<GameModel>()};
            tournament.GamesList.Add(new GameModel() { ID = 1, TreeLevel = 2 });
            return tournament;
        }

    }

    public class Tournament
    {
        public List<GameModel> GamesList { get; set; }
    }
}