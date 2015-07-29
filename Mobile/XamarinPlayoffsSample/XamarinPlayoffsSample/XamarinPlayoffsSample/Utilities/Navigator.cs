using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinPlayoffsSample.Interfaces;

namespace XamarinPlayoffsSample.Utilities
{
	public static class Navigator
	{
		private static INavigation navigationModule;

		public static void Init(INavigation navModule)
		{
			navigationModule = navModule;
		}

		public static async Task NavigateTo(Type viewType, object navigationParameter = null)
		{
			var newView = (ContentPage)Activator.CreateInstance(viewType);

			await navigationModule.PushAsync(newView);

			var navigableViewModel = newView.BindingContext as INavigable;
			if (navigableViewModel != null)
			{
				await navigableViewModel.OnNavigateTo(navigationParameter);
			}
		}
	}
}
