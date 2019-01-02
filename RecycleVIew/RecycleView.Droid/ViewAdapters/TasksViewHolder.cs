using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using RecycleVIew.Core.Services;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Binding.BindingContext;

namespace RecycleView.Droid
{

    public class TasksViewHolder : MvxRecyclerViewHolder
    {
        public TextView NameTaskHolder { get; set; }
        public CheckBox CheckTaskHolder { get; set; }

        public TasksViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {

            NameTaskHolder = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            CheckTaskHolder = itemView.FindViewById<CheckBox>(Resource.Id.checkBoxStatus);
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TasksViewHolder, ItemTask>();
                set.Bind(this.NameTaskHolder).To(x => x.Title);
                set.Bind(this.CheckTaskHolder).To(y => y.Status);
                set.Apply();
            });
        }
    }
}