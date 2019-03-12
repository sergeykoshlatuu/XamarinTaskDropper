using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using TaskDropper.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Views.InputMethods;
using Android.Widget;
using Xamarin.Auth;
using Xamarin.Auth.OAuth2;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.Services;
using Plugin.Permissions;

namespace TaskDropper.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "@string/app_name")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {

        public DrawerLayout DrawerLayout { get; set; }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            SetContentView(Resource.Layout.main_view);
            if (bundle == null)
            {
                
                if (!ViewModel.IsUserLogin())
                {
                    ViewModel.ShowGoogleLoginViewModelCommand.Execute(null);
                }
                else
                {
                    ViewModel.ShowHomeViewModelCommand.Execute(null);
                }

            }
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            return false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}