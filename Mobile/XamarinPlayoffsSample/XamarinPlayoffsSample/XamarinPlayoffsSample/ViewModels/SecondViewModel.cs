using GalaSoft.MvvmLight;

namespace XamarinPlayoffsSample.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        private string welcomeText;

        public string WelcomeText
        {
            get { return welcomeText; }
            set { Set(ref welcomeText, value); }
        }

        public SecondViewModel()
        {
            this.WelcomeText = "Witaj na mojej drugiej stronie!";
        }
    }
}
