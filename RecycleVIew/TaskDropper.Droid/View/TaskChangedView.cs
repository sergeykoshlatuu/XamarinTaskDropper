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
using Android.Views.InputMethods;
using System;
using Android.Graphics;

namespace RecycleView.Droid.Views
{
    [Activity(Label = "SecondActivity")]
    public class TaskChangedView : MvxAppCompatActivity<TaskChangedViewModel>
    {
        private InputMethodManager _imm;
        private LinearLayout _linearLayoutMain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.item_changed);
            

            Typeface newTypeface = Typeface.CreateFromAsset(Assets, "fonts.otf");
            FindViewById<EditText>(Resource.Id.title_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            FindViewById<EditText>(Resource.Id.description_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            FindViewById<CheckBox>(Resource.Id.status_check).SetTypeface(newTypeface, TypefaceStyle.Normal);
            FindViewById<TextView>(Resource.Id.done_txt).SetTypeface(newTypeface, TypefaceStyle.Normal);
            FindViewById<Button>(Resource.Id.Savetask).SetTypeface(newTypeface, TypefaceStyle.Normal);
            FindViewById<Button>(Resource.Id.Deletetask).SetTypeface(newTypeface, TypefaceStyle.Normal);


            var imageButton = FindViewById<ImageButton>(Resource.Id.imageButton);
            imageButton.Visibility = ViewStates.Invisible;
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            
            _linearLayoutMain = FindViewById<LinearLayout>(Resource.Id.main_layout);
            _linearLayoutMain.Click += CloseKeybordClick;
            toolbar.Click += CloseKeybordClick;
            _imm = (InputMethodManager)GetSystemService(InputMethodService);
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

        private void CloseKeybordClick(object sender, EventArgs e)
        {
            if (CurrentFocus == null)
            {
                return;
            }
            _imm.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            CurrentFocus.ClearFocus();
        }
    }
}
