using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using RecycleVIew.Core.Services;

namespace RecycleView.Droid.ViewAdapter
{
  
    public class TasksViewHolder : RecyclerView.ViewHolder
    {        
        public TextView Title { get; set; }
        public CheckBox Status { get; set; }
        
        public TasksViewHolder(View itemview) : base(itemview)
        {
            Title = itemview.FindViewById<TextView>(Resource.Id.textView);
            Status = itemview.FindViewById<CheckBox>(Resource.Id.checkbox);
        }
    }
}