using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XamarinPlayoffsSample.Pages;
using XamarinPlayoffsSample.Utilities;

namespace XamarinPlayoffsSample.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private string welcomeText;

        public string WelcomeText
        {
            get { return welcomeText; }
            set { Set(ref welcomeText, value); }
        }

        public MainMenuViewModel()
        {
            this.WelcomeText = "Witaj w mojej pierwszej stronie!";
        }

        public ICommand GoToTheSecondPageCommand
        {
            get
            {
                return new RelayCommand(GoToTheSecondPage);
            }
        }

        private async void GoToTheSecondPage()
        {
            await Navigator.NavigateTo(typeof(SecondPage));
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
