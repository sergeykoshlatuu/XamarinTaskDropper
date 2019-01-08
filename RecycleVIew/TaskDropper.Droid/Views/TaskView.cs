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
using MvvmCross.Platforms.Android.Views;
using RecycleVIew.Core.ViewModels;

namespace RecycleView.Droid.Views
{
    
       [Activity(Label = "SecondActivity")]
    public class TaskView : MvxAppCompatActivity<TaskChangeViewModel>
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondPage);
        }
    }
}