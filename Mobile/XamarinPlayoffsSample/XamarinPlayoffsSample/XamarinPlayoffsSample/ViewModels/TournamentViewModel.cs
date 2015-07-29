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
		private ObservableCollection<Game> _gamesDetail;

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
				LoadGamesList ();
			}
		}

		public ObservableCollection<Game> Games
		{
			get { return _gamesDetail; }
			set { Set(ref _gamesDetail, value); }
		}

		public TournamentViewModel()
		{
			_gamesDetail = new ObservableCollection<Game> ();
			_games = new List<Game> () 
			{
				new Game () { TreeLevel = 1, Team1="Team1" ,Result = "6:4", Team2="Team2" },
				new Game () { TreeLevel = 1, Team1="Team3" ,Result = "3:7", Team2="Team4" },
				new Game () { TreeLevel = 1, Team1="Team5" ,Result = "9:1", Team2="Team6" },
				new Game () { TreeLevel = 1, Team1="Team7" ,Result = "1:9", Team2="Team8" },
				new Game () { TreeLevel = 2, Team1="Team1" ,Result = "6:4", Team2="Team4" },
				new Game () { TreeLevel = 2, Team1="Team5" ,Result = "2:8", Team2="Team7" },
				new Game () { TreeLevel = 3, Team1="Team1" ,Result = "0:10", Team2="Team7" },
			};
			TreeLvl = 1;
			MaxTreeLvl = _games.Max(g => g.TreeLevel);
			MinTreeLvl = 1;
			LoadGamesList ();
		}

		private void LoadGamesList()
		{
			Games.Clear();
			foreach (var game in _games.Where(g => g.TreeLevel == TreeLvl)) 
				_gamesDetail.Add(game);
		}
	}

	public class Game
	{
		public int Id { get; set; }
		public int TreeLevel { get; set; }
		public string Team1 { get; set; }
		public string Result { get; set; }
		public string Team2 { get; set; }
	}
}

