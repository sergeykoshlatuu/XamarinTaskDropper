using System.Collections.Generic;
using System.Reflection;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Widget;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Converters;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;
using RecycleView.Droid;
using RecycleVIew.Core;
using RecycleVIew.Core.Interface;
using RecycleVIew.Core.Services;




namespace RecycleView.Droid
{
    public class Setup : MvxAppCompatSetup<RecycleVIew.Core.App>
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


        //protected override IMvxAndroidViewPresenter CreateViewPresenter()
        //{
        //    return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        //}

        //protected override void InitializeFirstChance()
        //{
        //    Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();
        //    var foo = Mvx.IoCProvider.Resolve<IDatabaseConnectionService>();
        //    base.InitializeFirstChance();
        //}

        protected override void InitializeLastChance()
        {
            Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();
            base.InitializeLastChance();
        }
        //protected override void InitializeLastChance()
        //{

        //    Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();

        //}

        protected override IMvxApplication CreateApp()
        {
            CreatableTypes()
                      .EndingWith("Service")
                      .AsInterfaces()
                      .RegisterAsLazySingleton();
            //Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();
            return base.CreateApp();
        }
    }
}