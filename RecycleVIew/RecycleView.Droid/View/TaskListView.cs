using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using RecycleVIew.Core.ViewModels;
using RecycleVIew.Core.Services;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Views;
using RecycleVIew.Core.Interface;
using MvvmCross;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Views;

namespace RecycleView.Droid.Views
{
    [Activity(Label = "RecycleView", MainLauncher = true)]
    public class TaskListView : MvxAppCompatActivity<TasksListViewModel>
    {
        MvxRecyclerView _recyclerView;      
        RecyclerView.LayoutManager _layoutManager;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new GridLayoutManager(this, 2);
            _layoutManager = new LinearLayoutManager(this);
            //_recyclerView.SetLayoutManager(_layoutManager);           
            var recyclerAdapter = new TaskListAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _recyclerView.Adapter = recyclerAdapter;

            var imageButton = FindViewById<ImageButton>(Resource.Id.imageButton);
            imageButton.Visibility = ViewStates.Visible;

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            //var toolbar = FindViewById<Toolbar>(Resource.Id.toobar);
            //SetActionBar(toolbar);
            SupportActionBar.Title = "TaskDropper";
        }

        

    }}
    
