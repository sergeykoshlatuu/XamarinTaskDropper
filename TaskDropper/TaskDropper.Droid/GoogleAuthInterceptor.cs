﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using TaskDropper.Droid.Views;

namespace TaskDropper.Droid
{
    [Activity(Label = "GoogleAuthInterceptor")]
    [
         IntentFilter
         (
             actions: new[] { Intent.ActionView },
             Categories = new[]
             {
                    Intent.CategoryDefault,
                    Intent.CategoryBrowsable
             },
             DataSchemes = new[]
             {
                // First part of the redirect url (Package name)
                "com.koshsy6363.xamarin"
             },
             DataPaths = new[]
             {
                // Second part of the redirect url (Path)
                "/oauth2redirect"
             }
         )
     ]
    public class GoogleAuthInterceptor : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Android.Net.Uri uri_android = Intent.Data;

            // Convert iOS NSUrl to C#/netxf/BCL System.Uri - common API
            Uri uri_netfx = new Uri(uri_android.ToString());

            // Send the URI to the Authenticator for continuation
            LoginFragment.Auth?.OnPageLoading(uri_netfx);
            //.IsVisible = false;
            Finish();
        }
    }
}