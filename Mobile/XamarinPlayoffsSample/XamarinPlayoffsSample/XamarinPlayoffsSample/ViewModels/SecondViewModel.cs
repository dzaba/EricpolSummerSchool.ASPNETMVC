using GalaSoft.MvvmLight;
using XamarinPlayoffsSample.Interfaces;
using System.Threading.Tasks;

namespace XamarinPlayoffsSample.ViewModels
{
	public class SecondViewModel : ViewModelBase, INavigable
	{
		private string welcomeText;

		public string WelcomeText
		{
			get { return welcomeText; }
			set { Set(ref welcomeText, value); }
		}

		public SecondViewModel()
		{
		}

		#region INavigable implementation

		public async Task OnNavigateTo(object navigationParameter)
		{
			await Task.Delay(5000);
			this.WelcomeText = "Witaj na mojej drugiej stronie!";
		}

		#endregion
	}
}
