using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayoffsCreator.Models;
using PlayoffsCreator.BusinessLogic;

namespace PlayoffsCreator.App_Start
{
    public class Initialize
    {
        static public void InitializeInstance()
        {
            PlayersList.Players = new List<PlayerModel>
            {
                new PlayerModel() {ID = 0, Name = "Bartłomiej", Surname = "Pokrzywiński"},
                new PlayerModel() {ID = 1, Name = "Andrzej", Surname = "Kopytko"},
                new PlayerModel() {ID = 2, Name = "Robert", Surname = "Stolarczyk"},
                new PlayerModel() {ID = 3, Name = "Ziemowit", Surname = "Marek"}
            };
        }
    }
}