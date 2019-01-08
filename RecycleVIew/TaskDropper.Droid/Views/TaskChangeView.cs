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
using MvvmCross.Platforms.Android.Views;
using RecycleVIew.Core.ViewModels;

namespace RecycleView.Droid.ViewModels
{
    [Activity(Label = "TaskChangeView")]
    public class TaskChangeView : MvxActivity<TaskChangeViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskChangeView);
        }
    }
}