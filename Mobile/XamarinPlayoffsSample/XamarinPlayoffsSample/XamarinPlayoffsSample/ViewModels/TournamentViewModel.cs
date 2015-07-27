using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Collections.ObjectModel;

namespace XamarinPlayoffsSample.ViewModels
{
	public class TournamentViewModel : ViewModelBase
	{
		private int _maxTreeLvl;
		private int _minTreeLvl;
		private int _treeLvl;
		private List<GameModel> _games;
		private ObservableCollection<string> _gamesDetail;

		public int MaxTreeLvl 
		{
			get { return _maxTreeLvl; }
			set { Set(ref _maxTreeLvl, value); }
		}

		public int MinTreeLvl 
		{
			get { return _minTreeLvl; }
			set { Set(ref _minTreeLvl, value); }
		}

		public int TreeLvl 
		{
			get 
			{
				return _treeLvl; 
			}
			set 
			{
				Set(ref _treeLvl, value); 
				PrepareGameDetailsList ();
			}
		}

		public ObservableCollection<string> Games
		{
			get { return _gamesDetail; }
			set { Set(ref _gamesDetail, value); }
		}

		public TournamentViewModel()
		{
			List<TeamModel> _teams = new List<TeamModel>()
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
               new GameModel() {ID = 4, Team1 = _teams[6], Team2 = _teams[7], TreeLevel = 1, Rounds = new List<RoundModel>()},
			   new GameModel() {ID = 5, Team1 = _teams[4], Team2 = _teams[5], TreeLevel = 2, Rounds = new List<RoundModel>()},
			   new GameModel() {ID = 6, Team1 = _teams[6], Team2 = _teams[7], TreeLevel = 2, Rounds = new List<RoundModel>()},
			   new GameModel() {ID = 6, Team1 = _teams[6], Team2 = _teams[5], TreeLevel = 3, Rounds = new List<RoundModel>()},
            };

			_gamesDetail = new ObservableCollection<string> ();
			foreach (var game in _games) 
			{
				game.PlayGame();
			}
			TreeLvl = 1;
			MaxTreeLvl = 3;
			MinTreeLvl = 1;
			PrepareGameDetailsList ();
		}

		private void PrepareGameDetailsList()
		{
			Games.Clear();
			foreach (var game in _games.Where(g => g.TreeLevel == TreeLvl)) 
			{
				_gamesDetail.Add (game.Team1.TeamName + " " + 
					game.Result().Values.First() + ":" + game.Result().Values.Last() +
					" " + game.Team2.TeamName);
			}
		}
	}
}

