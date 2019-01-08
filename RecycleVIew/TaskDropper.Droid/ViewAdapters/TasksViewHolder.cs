using Android.Widget;
using RecycleVIew.Core.Services;
using Android.Views;
using Android.Graphics;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Binding.BindingContext;
using RecycleView.Droid;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.App;
using Android.Content.Res;

namespace RecycleView.Droid.ViewAdapters
{
    public class TasksViewHolder : MvxRecyclerViewHolder
    {
        public TextView NameTaskHolder { get; set; }
        public CheckBox CheckTaskHolder { get; set; }
        //public MvxAppCompatActivity activity = new MvxAppCompatActivity();
        public Typeface newTypeface1 = Typeface.CreateFromAsset(Application.Context.Assets, "fonts.otf");
     
        public TasksViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {

            NameTaskHolder = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            CheckTaskHolder = itemView.FindViewById<CheckBox>(Resource.Id.checkBoxStatus);
            NameTaskHolder.SetTypeface(newTypeface1, TypefaceStyle.Normal);

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