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
    


    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        protected override int FragmentId => Resource.Layout.home_view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            //var view = this.BindingInflate(Resource.Layout.home_view,container);

            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            view.FindViewById<TextView>(Resource.Id.app_name_text).SetTypeface(newTypeface, TypefaceStyle.Normal);

          
            var addtask_button = view.FindViewById<ImageButton>(Resource.Id.addtask_button);
            addtask_button.Visibility = ViewStates.Visible;
            var back_button = view.FindViewById<ImageButton>(Resource.Id.back_button);
            back_button.Visibility = ViewStates.Invisible;

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

                for (int i = 0; i < tabLayout.TabCount; i++)
                {
                    TabLayout.Tab tab = tabLayout.GetTabAt(i);
                    tab.SetCustomView(adapter.GetTabView(i));
                }
            }

           
            return view;
        }
    }
}