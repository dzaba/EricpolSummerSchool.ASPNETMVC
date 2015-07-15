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

        public ActionResult Index(int id = 1)
        {
            // ------ tymczasowe dane do testowania. Finalnie będą pobierane z bazy danych -------
            List<TeamModel> teams = new List<TeamModel>()
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
            int teamsNum = teams.Count;
            List<GameModel> games = new List<GameModel>()
            {
                new GameModel() {ID = 1, Team1 = teams[0], Team2 = teams[1], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 2, Team1 = teams[2], Team2 = teams[3], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 3, Team1 = teams[4], Team2 = teams[5], TreeLevel = 1, Rounds = new List<RoundModel>()},
                new GameModel() {ID = 4, Team1 = teams[6], Team2 = teams[7], TreeLevel = 1, Rounds = new List<RoundModel>()}
            };
            
            foreach (var game in games)
                game.PlayGame();
            // -----------------------------------------


            // <numer gry, poziom na drzewie/drabince turnieju>
            IDictionary<int, int> treeLevels = new Dictionary<int, int>(); 

            //Obliczenie liczby rozgrywek w turnieju 
            int gamesNum = 0, treeLevel  = 1;
            for (int i = teamsNum/2; i >= 1; i /= 2)
            {
                for (int j = 1; j <= i; ++j)
                    treeLevels.Add(gamesNum + j, treeLevel);                    
                ++treeLevel;
                gamesNum += i;
            }

            if (games.Count < 4)
            {
                for (int i = games.Count*2; i < teamsNum; i += 2)
                    games.Add(new GameModel() { ID = 1, TreeLevel = 1, Team1 = teams[i], Team2 = teams[i + 1] });                    
            }
                
            
            TeamModel tmpTeam1 = new TeamModel() { ID = -1, TeamName = "?" };
            TeamModel tmpTeam2 = new TeamModel() { ID = -2, TeamName = "?" };
            
            //wypełnienie pustych węzłów drzewa turnieju  
            for (int i = games.Count + 1; i <= gamesNum; ++i)
                games.Add(new GameModel() { ID = 1, TreeLevel = treeLevels[i], Team1 = tmpTeam1, Team2 = tmpTeam2, Rounds = new List<RoundModel>() });                

            List<List<GameModel>> gamesTree = new List<List<GameModel>>();
            for (int i = 1; i <= games.Max(o => o.TreeLevel); ++i)
            {
                gamesTree.Add(new List<GameModel>());
                foreach (var game in games.Where(o => o.TreeLevel == i))
                    gamesTree[i - 1].Add(game);                    
            }
            
            //Ustawia nowe rozgrywki jeżeli poprzednie zostały przeprowadzone.
            for (int i = 1; i < gamesTree.Count; ++i)
            {
                for (int j = 0; j < gamesTree[i].Count; ++j)
                {
                    if (gamesTree[i - 1][j * 2].IsFinished() && gamesTree[i - 1][j * 2 + 1].IsFinished())
                    {
                        var result = gamesTree[i - 1][j * 2].Result();
                        gamesTree[i][j].Team1 = teams.Find(o => o.ID == 
                            (result.Values.First() < result.Values.Last() ? result.Keys.Last() : result.Keys.First()));
                        
                        result = gamesTree[i - 1][j * 2 + 1].Result();
                        gamesTree[i][j].Team2 = teams.Find(o => o.ID == 
                            (result.Values.First() < result.Values.Last() ? result.Keys.Last() : result.Keys.First()));
                    }
                }
            }

            //Symulator nowej rundy.
            if (id == 2)
            {
                foreach (var gs in gamesTree)
                {
                    if (!gs.All(o => o.IsFinished()))
                    {
                        foreach (var game in gs)
                            game.PlayGame();
                        break;
                    }
                }
            }
            return View(games);
        }

       

        

    }
}
