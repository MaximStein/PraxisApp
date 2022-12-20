using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PraxisApp
{
    public partial class App : Application
    {

        public static MasterDetailPage MasterDetailPage;


        public App()
        {
            InitializeComponent();

            App.MasterDetailPage = new MainPage();
            MainPage = App.MasterDetailPage;
        }
            
        public static async void PushDetailPage(ContentPage page)
        {
            var Detail = App.MasterDetailPage.Detail as NavigationPage;
            await Detail.PushAsync(page);

            App.MasterDetailPage.IsPresented = false;
        }

        public static void SetDetailPage(Page page)
        {
            NavigationPage NavPage = new NavigationPage(page);
            NavPage.Title = "_";
            App.MasterDetailPage.Detail = NavPage;
            App.MasterDetailPage.IsPresented = false;
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
