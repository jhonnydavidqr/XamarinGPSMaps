using App1GPS.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1GPS
{
    public partial class App : Application
    {
        static NavigationPage navPage;

        public App()
        {
            //InitializeComponent();

            //MainPage = new MainPage();
            MainPage = FrontPage();
        }

        public static Page FrontPage()
        {
            navPage = new NavigationPage(new GoogleMapScreen());
            return navPage;
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
