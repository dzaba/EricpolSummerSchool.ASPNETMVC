using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XamarinPlayoffsSample.Pages;
using XamarinPlayoffsSample.Utilities;

namespace XamarinPlayoffsSample.ViewModels
{
    public class PlayerApiViewModel : ViewModelBase
    {
        private string welcomeText;

        public string WelcomeText
        {
            get { return welcomeText; }
            set { Set(ref welcomeText, value); }
        }

        public PlayerApiViewModel()
        {
            this.WelcomeText = "Widok API graczy";
        }

        public ICommand GoToPlayerCommend
        {
            get
            {
                return new RelayCommand(GoToPlayersApiCommand);
            }
        }

        private async void GoToPlayersApiCommand()
        {
            await Navigator.NavigateTo(typeof(PlayerApiViewModel));
        }
    }
}
