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
		private List<Game> _games;
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
			get { return _treeLvl;}
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
			_gamesDetail = new ObservableCollection<string> ();
			_games = new List<Game> () 
			{
				new Game () { TreeLevel = 1, Result = "Team1 6:4 Team2" },
				new Game () { TreeLevel = 1, Result = "Team3 7:3 Team4" },
				new Game () { TreeLevel = 1, Result = "Team5 10:0 Team6" },
				new Game () { TreeLevel = 1, Result = "Team7 9:1 Team8" },
				new Game () { TreeLevel = 2, Result = "Team1 8:2 Team3" },
				new Game () { TreeLevel = 2, Result = "Team5 0:10 Team7" },
				new Game () { TreeLevel = 3, Result = "Team1 1:9 Team7" },
			};
			TreeLvl = 1;
			MaxTreeLvl = 3;
			MinTreeLvl = 1;
			PrepareGameDetailsList ();
		}

		private void PrepareGameDetailsList()
		{
			Games.Clear();
			foreach (var game in _games.Where(g => g.TreeLevel == TreeLvl)) 
				_gamesDetail.Add (game.Result);
		}
	}

	public class Game
	{
		public int TreeLevel { get; set; }
		public string Result { get; set; }
	}
}

