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
        private static readonly NSString TaskCellIdentifier = new NSString("TaskCell");

        public TasksTVS(UITableView tableView)
            : base(tableView)
        {
            tableView.RegisterNibForCellReuse(UINib.FromName("TaskCell", NSBundle.MainBundle),
                                              TaskCellIdentifier);
            
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (TaskCell)tableView.DequeueReusableCell("TaskCell", indexPath); 
            cell.UpdateCell((ItemTask)item);
            return (UITableViewCell)cell;        
        }
    }
}