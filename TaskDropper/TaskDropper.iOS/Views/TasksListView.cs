using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System;
using TaskDropper.Core.Models;
using TaskDropper.Core.ViewModels;
using UIKit;

namespace TaskDropper.iOS.Views
{
    public partial class TasksListView : MvxViewController<TasksListViewModel>
    {
        public MvxObservableCollection<ItemTask> TaskCollection { get; set; }

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
            //set.Bind(TaskCollection).To(vm => vm.TaskCollection);

            set.Bind(source).To(m => m.TaskCollection);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ShowTaskChangedView);
            //set.Bind(Plus).To(m => m.ShowTaskChangedView);

            var _addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(_addButton, false);
            set.Bind(_addButton).To(m => m.ShowTaskChangedView);

            set.Apply();


            // this is optional. What this code does is to close the keyboard whenever you 
            // tap on the screen, outside the bounds of the TextField

        }
    }
}