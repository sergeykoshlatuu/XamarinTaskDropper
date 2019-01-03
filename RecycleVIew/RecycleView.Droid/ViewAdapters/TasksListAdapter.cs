using Android.Support.V7.Widget;
using Android.Views;
using System;
using RecycleVIew.Core.Services;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace RecycleView.Droid.ViewAdapters
{
    public class TaskListAdapter : MvxRecyclerAdapter
    {
        public TaskListAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = this.InflateViewForHolder(parent, viewType, itemBindingContext);
            return new TasksViewHolder(view, itemBindingContext)
            {
                Click = ItemClick,
                LongClick = ItemLongClick
            };
        }
    }
}