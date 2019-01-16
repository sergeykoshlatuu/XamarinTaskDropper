using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;

namespace TaskDropper.Droid.ViewAdapters
{
    public class MvxViewPagerFragmentAdapter
        : FragmentPagerAdapter
    {
        
        private string[] tabTitles = { "TaskList", "About" };
        private readonly Context _context;
        public IEnumerable<FragmentInfo> Fragments { get; private set; }

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
            tv.Text = tabTitles[position];
            return tv;
        }

    }
}