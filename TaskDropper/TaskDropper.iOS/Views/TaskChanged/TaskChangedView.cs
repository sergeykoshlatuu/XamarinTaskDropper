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
            //set.Bind(Photo).For(v => v.Image).To(vm => vm.Photo).WithConversion("InMemoryImage");

            //var _backButton = new UIBarButtonItem(UIBarButtonSystemItem.Reply, null);
            //NavigationItem.SetLeftBarButtonItem(_backButton, false);
            //set.Bind(_backButton).To(m => m.BackCommand);

            set.Apply();


            // this is optional. What this code does is to close the keyboard whenever you 
            // tap on the screen, outside the bounds of the TextField

            TitleTextField.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
            DescriptionTextField.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5

            View.AddGestureRecognizer(g);
        }

        partial void AttachPhoto_TouchUpInside(UIButton sender)
        {
            var alert = UIAlertController.Create("Attach Photo", "How you can attach photo?", UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("Photo from gallary", UIAlertActionStyle.Default,(UIAlertAction obj)=>
                {
                    ViewModel.ChoosePictureCommand.Execute();

                }));

            alert.AddAction(UIAlertAction.Create("Photo from camera", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                ViewModel.TakePictureCommand.Execute();

            }));

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
            }));

            PresentViewController(alert, true, null);
        }
    }
}
