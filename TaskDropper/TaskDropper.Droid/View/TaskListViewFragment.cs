using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using TaskDropper.Core.ViewModels;
using TaskDropper.Core.Services;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Views;
using TaskDropper.Core.Interface;
using MvvmCross;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Views;
using TaskDropper.Droid.ViewAdapters;
using Android.Graphics;

namespace TaskDropper.Droid.Views
{
    [Activity(Label = "RecycleView", MainLauncher = true)]
    public class TaskListView : MvxAppCompatActivity<TasksListViewModel>
    {
        MvxRecyclerView _recyclerView;
        RecyclerView.LayoutManager _layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.list_items);
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);

            _layoutManager = new GridLayoutManager(this, 2);
            _layoutManager = new LinearLayoutManager(this);
            //_recyclerView.SetLayoutManager(_layoutManager);           
            var recyclerAdapter = new TaskListAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _recyclerView.Adapter = recyclerAdapter;

            //Typeface newTypeface = Typeface.CreateFromAsset(Assets, "fonts.otf");
            //FindViewById<TextView>(Resource.Id.textViewTitle).SetTypeface(newTypeface, TypefaceStyle.Normal);


            var imageButton = FindViewById<ImageButton>(Resource.Id.imageButton);
            imageButton.Visibility = ViewStates.Visible;

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            //var toolbar = FindViewById<Toolbar>(Resource.Id.toobar);
            //SetActionBar(toolbar);
            SupportActionBar.Title = "TaskDropper";
        }



    }
}

