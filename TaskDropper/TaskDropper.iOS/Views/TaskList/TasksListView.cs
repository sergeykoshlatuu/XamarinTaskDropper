using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System;
using TaskDropper.Core.Models;
using TaskDropper.Core.ViewModels;
using UIKit;

namespace TaskDropper.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class TasksListView : MvxViewController<TasksListViewModel>
    {
        public TasksListView() : base(nameof(TasksListView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TasksTable.RegisterNibForCellReuse(TaskCell.Nib, TaskCell.Key);
            var source = new TasksTVS(TasksTable);
            TasksTable.Source = source;
            var set = this.CreateBindingSet<TasksListView, TasksListViewModel>();
            set.Bind(source).To(m => m.TaskCollection);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ShowTaskChangedView);
            
           
            set.Apply();
        }
    }
}