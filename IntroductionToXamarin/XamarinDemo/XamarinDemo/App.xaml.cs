using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemo.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BreedListView());
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
