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
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.Droid.Views
{
  [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class AboutFragment : BaseFragment<AboutViewModel>
    {
        protected override int FragmentId => Resource.Layout.about_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            //Typeface newTypeface = Typeface.CreateFromAsset(Assets, "fonts.otf");
            //FindViewById<TextView>(Resource.Id.textViewTitle).SetTypeface(newTypeface, TypefaceStyle.Normal);


            var imageButton = view.FindViewById<ImageButton>(Resource.Id.imageButton);
            imageButton.Visibility = ViewStates.Visible;

            var toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            //SetSupportActionBar(toolbar);

            ////var toolbar = FindViewById<Toolbar>(Resource.Id.toobar);
            ////SetActionBar(toolbar);
            //SupportActionBar.Title = "TaskDropper";

            return view;
        }



    }
}



