using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TaskDropper.Droid.ViewAdapters;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using TaskDropper.Core.ViewModels;

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
            SetupRecyclerView(view);
            return view;
        }

        public void SetupRecyclerView(View view)
        {
            _recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new LinearLayoutManager(this.Context);
            _recyclerView.SetLayoutManager(_layoutManager);
            var recyclerAdapter = new TaskListAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _recyclerView.Adapter = recyclerAdapter;
        }
    }
}
