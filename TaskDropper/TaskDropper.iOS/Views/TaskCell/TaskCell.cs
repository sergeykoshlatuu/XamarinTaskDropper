using System;

using Foundation;
using TaskDropper.Core.Models;
using UIKit;

namespace TaskDropper.iOS.Views
{
    public partial class TaskCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("TaskCell");
        public static readonly UINib Nib;

        static TaskCell()
        {
            Nib = UINib.FromName("TaskCell", NSBundle.MainBundle);
        }

        protected TaskCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        internal void UpdateCell(ItemTask task)
        {
            titleLabel.Text = task.Title;
            statusSwitch.On = task.Status;
            statusSwitch.Enabled = false;
        }
    }
}
