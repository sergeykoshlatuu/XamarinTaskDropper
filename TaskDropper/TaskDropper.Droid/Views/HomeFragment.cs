using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
            {
                var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
                {
                    new MvxViewPagerFragmentAdapter.FragmentInfo
                    {
                        FragmentType = typeof(AboutViewModel),
                        Title = "",
                        ViewModel = ViewModel.AboutsViewModel
                    },
                    new MvxViewPagerFragmentAdapter.FragmentInfo
                    {
                        FragmentType = typeof(AboutViewModel),
                        Title = "",
                        ViewModel = ViewModel.AboutsViewModel
                    },

                };
                viewPager.Adapter = new MvxViewPagerFragmentAdapter(Activity, ChildFragmentManager, fragments);
            }

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            return view;
        }
    }
}