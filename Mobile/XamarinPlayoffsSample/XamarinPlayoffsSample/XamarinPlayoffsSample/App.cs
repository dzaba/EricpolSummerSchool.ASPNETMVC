using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinPlayoffsSample.Pages;
using XamarinPlayoffsSample.Utilities;

namespace XamarinPlayoffsSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var mainPage = new MainMenuPage();
            var navigationPage = new NavigationPage(mainPage);
            Navigator.Init(navigationPage.Navigation);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
