using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Widget;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Reflection;
using TaskDropper.Core.Interface;
using TaskDropper.Forms.Droid.Services;

namespace TaskDropper.Forms.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, App>
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(NavigationView).Assembly,
            typeof(CoordinatorLayout).Assembly,
            typeof(FloatingActionButton).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(DrawerLayout).Assembly,
            typeof(ViewPager).Assembly,
            typeof(MvxSwipeRefreshLayout).Assembly,
            typeof(RelativeLayout).Assembly,
            typeof(FrameLayout).Assembly,
            typeof(EditText).Assembly,
            typeof(Android.Support.V7.Widget.SwitchCompat).Assembly,
            typeof(LinearLayout).Assembly,
            typeof(CheckedTextView).Assembly,
            typeof(MvxValueConverter).Assembly
        };

        protected override IMvxApplication CreateApp()
        {
            CreatableTypes()
                      .EndingWith("Service")
                      .AsInterfaces()
                      .RegisterAsLazySingleton();
            Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();

            //Mvx.RegisterType<IPhotoService, PhotoService>();
            return base.CreateApp();
        }
    }
}