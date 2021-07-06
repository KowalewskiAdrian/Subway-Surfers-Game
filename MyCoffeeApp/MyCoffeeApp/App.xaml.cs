using System;
using System.Diagnostics;
using MonkeyCache.FileStore;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyCoffeeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppInfo.PackageName;
            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        //public event EventHandler<Xamarin.Forms.Page> PageAppearing;

        protected override void OnStart()
        {
            Console.WriteLine("[MyCoffeeApp] OnStart");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("[MyCoffeeApp] OnSleep");
        }

        protected override void OnResume()
        {
            Console.WriteLine("[MyCoffeeApp] OnResume");
        }

        protected void OnPageAppearing(Page page)
        {
            Console.WriteLine($"[MyCoffeeApp] OnPageAppearing {page.Title}");
        }

        //protected void OnPageAppearing(Page e)
        //{
        //    Console.WriteLine($"[MyCoffeeApp] OnPageAppearing {e.Title}");
        //    //PageAppearing?.Invoke(this, e);
        //}

    }
}
