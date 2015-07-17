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
        private Contexts _db = new Contexts();
        private List<TeamModel> _teams;
        private List<GameModel> _games;
        private List<List<GameModel>> _gamesTree;
        //
        // GET: /Tournament/
        public ActionResult Index()
        {
            GetData();                

            // <numer gry, poziom na drzewie/drabince turnieju>
            IDictionary<int, int> treeLvlForGame = new Dictionary<int, int>(); 
            int gamesNum = 0;
            
            for (int i = _teams.Count/2, lvl = 1; i >= 1; i /= 2, lvl++)
            {
                for (int j = 1; j <= i; ++j)
                    treeLvlForGame.Add(gamesNum + j, lvl);                    
                gamesNum += i;
            }

            if (_games.Count < _teams.Count/2)
            {
                for (int i = _games.Count * 2; i < _teams.Count; i += 2)
                    _games.Add( new GameModel()
                    {
                        ID = 1, 
                        TreeLevel = 1, 
                        Team1 = _teams[i], 
                        Team2 = _teams[i + 1],
                        Rounds = new List<RoundModel>()
                    });                    
            }
            //wypełnienie pustych węzłów drzewa turnieju  
            for (int i = _games.Count + 1; i <= gamesNum; ++i)
            {
                _games.Add(new GameModel()
                {
                    ID = 1,
                    TreeLevel = treeLvlForGame[i],
                    Team1 = new TeamModel() { ID = -1, TeamName = "?" },
                    Team2 = new TeamModel() { ID = -2, TeamName = "?" },
                    Rounds = new List<RoundModel>()
                });  
            }

            //Dobiera wygrane drużyny i przypisuje je do nowej gry.
            for (int i = 1; i < _gamesTree.Count; ++i)
            {
                for (int j = 0; j < _gamesTree[i].Count; ++j)
                {
                    if (_gamesTree[i - 1][j * 2].IsFinished() && _gamesTree[i - 1][j * 2 + 1].IsFinished())
                    {
                        IDictionary<int, int> result = _gamesTree[i - 1][j * 2].Result();
                        _gamesTree[i][j].Team1 = _teams.Find(o => o.ID == 
                            (result.Values.First() < result.Values.Last() ? result.Keys.Last() : result.Keys.First()));
                        
                        result = _gamesTree[i - 1][j * 2 + 1].Result();
                        _gamesTree[i][j].Team2 = _teams.Find(o => o.ID == 
                            (result.Values.First() < result.Values.Last() ? result.Keys.Last() : result.Keys.First()));
                    }
                }
            }
            return View(_games);
        }

        [HttpPost]
        public ActionResult RunSimulation()
        {
            GetData();
            foreach (var gs in _gamesTree)
            {
                if (!gs.All(o => o.IsFinished()))
                {
                    foreach (var game in gs)
                        if(!game.IsFinished())
                            game.PlayGame();
                    break;
                }
            }
//            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        private void GetData()
        {
            _teams = new List<TeamModel>()
            {
                new TeamModel() {ID = 1, TeamName = "Team1"},
                new TeamModel() {ID = 2, TeamName = "Team2"},
                new TeamModel() {ID = 3, TeamName = "Team3"},
                new TeamModel() {ID = 4, TeamName = "Team4"},
                new TeamModel() {ID = 5, TeamName = "Team5"},
                new TeamModel() {ID = 6, TeamName = "Team6"},
                new TeamModel() {ID = 7, TeamName = "Team7"},
                new TeamModel() {ID = 8, TeamName = "Team8"},
            };

            _games = new List<GameModel>()
            {
                new GameModel() {ID = 1, Team1 = _teams[0], Team2 = _teams[1], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 2, Team1 = _teams[2], Team2 = _teams[3], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 3, Team1 = _teams[4], Team2 = _teams[5], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 4, Team1 = _teams[6], Team2 = _teams[7], TreeLevel = 1, Rounds = new List<RoundModel>()}
            };

            foreach (var game in _games)
                game.PlayGame();

            _teams = _db.Teams.ToList();
//            _games = _db.GameModels.ToList();

            _gamesTree = new List<List<GameModel>>();
            for (int i = 1; i <= _games.Max(o => o.TreeLevel); ++i)
            {
                _gamesTree.Add(new List<GameModel>());
                foreach (var game in _games.Where(o => o.TreeLevel == i))
                    _gamesTree[i - 1].Add(game);
            }
        }

        
    }
}
