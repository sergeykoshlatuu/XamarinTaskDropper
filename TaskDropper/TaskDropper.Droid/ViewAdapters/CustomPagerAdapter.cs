using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using TaskDropper.Droid.Views;

namespace TaskDropper.Droid.ViewAdapters
{
    public class CustomPagerAdapter : FragmentPagerAdapter
    {
        const int PAGE_COUNT = 2;
        private string[] tabTitles = { "TaskList", "About" };
        readonly Context context;
        public List<MvxFragment> Fragments { get; private set; }

        public CustomPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomPagerAdapter(Context context, FragmentManager fm, List<MvxFragment> fragments) : base(fm)
        {
            this.context = context;
            Fragments = fragments;
        }

        public override int Count
        {
            get { return PAGE_COUNT; }
        }

        public override Fragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }

        public View GetTabView(int position)
        {
            // Given you have a custom layout in `res/layout/custom_tab.xml` with a TextView
            var tv = (TextView)LayoutInflater.From(context).Inflate(Resource.Layout.custom_tab, null);
            tv.Text = tabTitles[position];
            return tv;
        }
    }
}