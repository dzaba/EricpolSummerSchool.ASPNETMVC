using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPlayoffsSample.Utilities
{
    public static class Navigator
    {
        private static INavigation navigationModule;

        public static void Init(INavigation navModule)
        {
            navigationModule = navModule;
        }

        public static async Task NavigateTo(Type viewType)
        {
            var newView = (ContentPage)Activator.CreateInstance(viewType);

            await navigationModule.PushAsync(newView);
        }
    }
}
