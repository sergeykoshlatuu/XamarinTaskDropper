using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views;
using RecycleVIew.Core.ViewModels;
using MvvmCross.Navigation;
using RecycleVIew.Core.Services;
using MvvmCross.Platforms.Android.Views;
using RecycleView.Droid.ViewAdapter;

namespace RecycleView.Droid.Views
{
    [Activity(Label = "RecycleView", MainLauncher = true)]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        RecyclerView _recyclerView;
        TaskListAdapter _adapter;
        RecyclerView.LayoutManager _layoutManager;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.MainView);
            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Hello";
            _recyclerView = this.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            ViewModel.Items.CollectionChanged += Items_CollectionChanged;
            _adapter = new TaskListAdapter(ViewModel.Items);
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            _recyclerView.SetAdapter(_adapter);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.itemmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _recyclerView.SetLayoutManager(_layoutManager);
            _recyclerView.SetAdapter(_adapter);
        }
    }
}