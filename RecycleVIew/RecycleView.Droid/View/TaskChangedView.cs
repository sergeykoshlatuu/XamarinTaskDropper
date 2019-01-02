using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using RecycleVIew.Core.ViewModels;
using RecycleVIew.Core.Services;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Views;
using RecycleVIew.Core.Interface;
using MvvmCross;
using Android.Views;

namespace RecycleView.Droid.Views
{
    [Activity(Label = "SecondActivity")]
    public class TaskChangedView : MvxAppCompatActivity<TaskChangedViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondPage);


            var imageButton = FindViewById<ImageButton>(Resource.Id.imageButton);
            imageButton.Visibility = ViewStates.Invisible;
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "";
           
            var actionBar = SupportActionBar;
            if (actionBar != null)
            {
                actionBar.SetDisplayHomeAsUpEnabled(true);
            }
        }

            public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                OnBackPressed();
            }

            return base.OnOptionsItemSelected(item);
        }
    }
    }
