using System;
using dbmobiletest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dbmobiletest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SelectDB());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
