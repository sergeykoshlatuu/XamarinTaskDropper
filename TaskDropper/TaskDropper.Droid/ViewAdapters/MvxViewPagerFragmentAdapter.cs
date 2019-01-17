using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;
using Android.App;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
namespace TaskDropper.Droid.ViewAdapters
{
    public class MvxViewPagerFragmentAdapter
        : FragmentPagerAdapter
    {
        
        private string[] tabTitles = { "TaskList", "About" };
        private readonly Context _context;
        public IEnumerable<FragmentInfo> Fragments { get; private set; }
        public Typeface newTypeface1 = Typeface.CreateFromAsset(Application.Context.Assets, "NK123.otf");

        public override int Count
        {
            get { return Fragments.Count(); }
        }

        public MvxViewPagerFragmentAdapter(
            Context context, FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
            : base(fragmentManager)
        {
            _context = context;
            Fragments = fragments;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }

        public override Fragment GetItem(int position)
        {
            var fragmentInfo = Fragments.ElementAt(position);
            var fragment = Fragment.Instantiate(_context,
                FragmentJavaName(fragmentInfo.FragmentType));
            ((MvxFragment)fragment).ViewModel = fragmentInfo.ViewModel;
            return fragment;
        }

        protected static string FragmentJavaName(Type fragmentType)
        {
            //var namespaceText = fragmentType.Namespace ?? "";
            //if (namespaceText.Length > 0)
            //    namespaceText = namespaceText.ToLowerInvariant() + ".";
            //return namespaceText + fragmentType.Name;
            return Java.Lang.Class.FromType(fragmentType).Name;


        }

       

        public class FragmentInfo
        {
            public string Title { get; set; }
            public Type FragmentType { get; set; }
            public IMvxViewModel ViewModel { get; set; }
        }

        public View GetTabView(int position)
        {
            // Given you have a custom layout in `res/layout/custom_tab.xml` with a TextView
            var tv = (TextView)LayoutInflater.From(_context).Inflate(Resource.Layout.custom_tab, null);
            tv.SetTypeface(newTypeface1, TypefaceStyle.Normal);
            tv.Text = tabTitles[position];
            return tv;
        }

    }
}