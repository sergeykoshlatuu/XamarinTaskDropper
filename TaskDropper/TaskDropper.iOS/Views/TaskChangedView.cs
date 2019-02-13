using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System;
using TaskDropper.Core.Models;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.iOS.Views
{
    public partial class TaskChangedView : MvxViewController<TaskChangedViewModel>
    {
        public MvxObservableCollection<ItemTask> TaskCollection { get; set; }

        public TaskChangedView() : base(nameof(TaskChangedView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           

            var set = this.CreateBindingSet<TaskChangedView, TaskChangedViewModel>();
            set.Bind(TitleTextField).To(vm => vm.Title);
            set.Bind(DescriptionTextField).To(vm => vm.Description);
            set.Bind(StatusSwitch).To(vm => vm.Status);
            set.Bind(SaveButton).To(vm => vm.SaveCommand);
            set.Bind(DeleteButton).To(vm => vm.DeleteCommand);

            set.Apply();


            // this is optional. What this code does is to close the keyboard whenever you 
            // tap on the screen, outside the bounds of the TextField

        }
    }
}
