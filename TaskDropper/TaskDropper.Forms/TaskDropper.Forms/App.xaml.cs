using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaskDropper.Forms
{
        public partial class App : Application
        {
            public App()
            {
                InitializeComponent();
            }

            protected override void OnStart()
            {
                base.OnStart();
            }

            protected override void OnSleep()
            {
                base.OnSleep();
            }

            protected override void OnResume()
            {
                base.OnResume();
            }
        }
}
