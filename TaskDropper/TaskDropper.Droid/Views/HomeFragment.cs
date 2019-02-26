using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TaskDropper.Core.ViewModels;
using TaskDropper.Droid.ViewAdapters;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame,addToBackStack:false)]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        protected override int FragmentId => Resource.Layout.home_view;
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            SetupHomeActionBar(view);
            SetupFonts(view);
            SetupViewPager(view);

            //ShowOrHide_no_internet_text_view(view);
            return view;
        }

        public void SetupViewPager(View view)
        {
           var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
            {
                var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
                {
                    new MvxViewPagerFragmentAdapter.FragmentInfo
                    {
                        FragmentType = typeof(TaskListFragment),
                        Title = "",
                        ViewModel = ViewModel.TaskListViewModel
                    },
                    new MvxViewPagerFragmentAdapter.FragmentInfo
                    {
                        FragmentType = typeof(AboutFragment),
                        Title = "",
                        ViewModel = ViewModel.AboutViewModel
                    },

                };
                var adapter = new MvxViewPagerFragmentAdapter(Activity, ChildFragmentManager, fragments);
                viewPager.Adapter = adapter;

                var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
                tabLayout.SetupWithViewPager(viewPager);
                tabLayout.DrawingCacheBackgroundColor = Color.Black;

                for (int i = 0; i < tabLayout.TabCount; i++)
                {
                    TabLayout.Tab tab = tabLayout.GetTabAt(i);
                    tab.SetCustomView(adapter.GetTabView(i));

                }
            }
        }

       //private void  ShowOrHide_no_internet_text_view(View view)
       // {
       //     var no_internet_text_view = view.FindViewById<TextView>(Resource.Id.no_internet_text_view);
       //     if (!ViewModel.ChangedNetworkAccess)
       //     {
       //         no_internet_text_view.Visibility = ViewStates.Visible;
       //         return;
       //     }
       //     no_internet_text_view.Visibility = ViewStates.Invisible;
       // }
        public void SetupFonts(View view)
        {
            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            view.FindViewById<TextView>(Resource.Id.app_name_text).SetTypeface(newTypeface, TypefaceStyle.Normal);
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (item.ItemId == (int)Keycode.Home)
            {
                return false;
            }
            return true;
        }
    }
}