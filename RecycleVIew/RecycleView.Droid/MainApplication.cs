using System;
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
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using RecycleVIew.Core;
using RecycleView.Droid;
using Android.Graphics;

namespace RecycleView.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup,App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }
    }
}