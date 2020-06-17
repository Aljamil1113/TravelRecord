using System;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelRecord
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static User user = new User();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string _DatabaseLocation)
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = _DatabaseLocation;
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
