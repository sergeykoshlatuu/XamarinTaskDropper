using System;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using UIKit;

namespace TaskDropper.iOS.Views
{
    internal class TasksTVS : MvxTableViewSource
    {
        private MvxObservableCollection<ItemTask> taskCollection;
        private static readonly NSString TaskCellIdentifier = new NSString("TaskCell");

        public TasksTVS(UITableView tableView)
            : base(tableView)
        {
            tableView.RegisterNibForCellReuse(UINib.FromName("TaskCell", NSBundle.MainBundle),
                                              TaskCellIdentifier);
            
        }

        //public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        //{
        //    var cell = (TaskCell)tableView.DequeueReusableCell("TaskCell", indexPath);
        //    var task = taskCollection[indexPath.Row];
        //    cell.UpdateCell(task);
        //    return (UITableViewCell)cell;
        //}

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (TaskCell)tableView.DequeueReusableCell("TaskCell", indexPath); 
            cell.UpdateCell((ItemTask)item);
            return (UITableViewCell)cell;

            //NSString cellIdentifier;
            //cellIdentifier = TaskCellIdentifier;
            //return (UITableViewCell)TableView.DequeueReusableCell(cellIdentifier, indexPath);
        }
    }
}