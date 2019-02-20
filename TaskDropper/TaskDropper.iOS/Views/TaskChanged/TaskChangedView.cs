using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        UIButton _logoutButton = new UIButton(UIButtonType.Custom);
        UIButton _backButton = new UIButton(UIButtonType.Custom);

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(43, 61, 80);
            NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.Black };
            //this.NavigationController.NavigationBar.TintColor = UIColor.FromRGB(43, 61, 80);

            var set = this.CreateBindingSet<TaskChangedView, TaskChangedViewModel>();
            set.Bind(TitleTextField).To(vm => vm.Title);
            
            set.Bind(DescriptionTextField).To(vm => vm.Description);
           
            set.Bind(StatusSwitch).To(vm => vm.Status);
            //set.Bind(SaveButton).To(vm => vm.SaveCommand);
            set.Bind(DeleteButton).To(vm => vm.DeleteCommand);
            set.Bind(PhotoImageView).For(v => v.Image).To(vm => vm.Photo).WithConversion("InMemoryImage");
            set.Bind(SaveButton).For(v=>v.Enabled).To(vm => vm.IsSavingEnabled);
            set.Bind(DetachPhotoButton).For(v => v.Enabled).To(vm => vm.IsDetachEnabled);
            set.Bind(DetachPhotoButton).To(vm => vm.DettachPhoto);
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
            
            _backButton.Frame = new CGRect(0, 0, 40, 40);
            _backButton.SetImage(UIImage.FromBundle("BackButton"), UIControlState.Normal);


            
            _logoutButton.Frame = new CGRect(0, 0, 40, 40);
            _logoutButton.SetImage(UIImage.FromBundle("LogOutButton"), UIControlState.Normal);

           
            NavigationItem.SetRightBarButtonItem( new UIBarButtonItem(_logoutButton), false);
            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(_backButton), false);

            //set.Bind(_addbutton).To(m => m.ShowTaskChangedViewCommand);


            _logoutButton.TouchUpInside += LogoutButtonClick;
            _backButton.TouchUpInside += BackButtonClick;
            SaveButton.TouchUpInside += SaveButtonClick;
            
            AttachPhotoButton.TouchUpInside += AttachPhotoClick;
            set.Apply();
        }


        private void SaveButtonClick(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            ViewModel.BackCommand.Execute();
        }

        private void LogoutButtonClick(object sender, EventArgs e)
        {
            ViewModel.LogOutUserCommand.Execute();
        }

        private void AttachPhotoClick(object sender, EventArgs e)
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

        public override void ViewDidUnload()
        {
            _logoutButton.TouchUpInside -= LogoutButtonClick;
            _backButton.TouchUpInside -= BackButtonClick;
            SaveButton.TouchUpInside -= SaveButtonClick;
            AttachPhotoButton.TouchUpInside -= AttachPhotoClick;
        }
    }
}
