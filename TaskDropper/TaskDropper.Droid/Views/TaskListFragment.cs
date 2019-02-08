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
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class TaskListFragment : BaseFragment<TasksListViewModel>
    {
        protected override int FragmentId => Resource.Layout.list_items;
        MvxRecyclerView _recyclerView;
        RecyclerView.LayoutManager _layoutManager;
        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new LinearLayoutManager(this.Context);
            _recyclerView.SetLayoutManager(_layoutManager);           
            var recyclerAdapter = new TaskListAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _recyclerView.Adapter = recyclerAdapter;
            return view;
        }
    }
}
