using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.iOS.Views
{

    public partial class TasksListView : MvxViewController<TasksListViewModel>
    {
        private MvxUIRefreshControl _refreshControl;

        public TasksListView() : base(nameof(TasksListView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _refreshControl = new MvxUIRefreshControl();

            TasksTable.RegisterNibForCellReuse(TaskCell.Nib, TaskCell.Key);
            var source = new TasksTVS(TasksTable);
            TasksTable.Source = source;
            TasksTable.AddSubview(_refreshControl);
            var set = this.CreateBindingSet<TasksListView, TasksListViewModel>();
            set.Bind(source).To(m => m.TaskCollection);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ShowTaskChangedView);

            set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.IsRefreshTaskCollection);
            set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshTaskCommand);
            set.Bind(NoInternetConnection).For(v => v.Hidden).To(vm => vm.IsNoInternetVisible);

            set.Apply();
        }
    }
}