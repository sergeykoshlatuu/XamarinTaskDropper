using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TaskDropper.Core.ViewModels;
using UIKit;

namespace TaskDropper.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : MvxTabBarViewController<HomeViewModel>
    {
        public HomeView() : base()
        {
            tab1 = new TasksListView();
            tab1.Title = "TaskList";
            tab1.ViewModel = ViewModel.TaskListViewModel;
            tab1.ModalPresentationStyle = UIModalPresentationStyle.CurrentContext;
            
            tab2 = new AboutView();
            tab2.Title = "About";
            tab2.ViewModel = ViewModel.AboutViewModel;

            var tabs = new MvxViewController[] {
                tab1, tab2
            };
            
            ViewControllers = tabs;
            
            
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];

        }

        MvxViewController tab1, tab2;

       

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();          
            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            var _addbutton = new UIButton(UIButtonType.Custom);
            _addbutton.Frame = new CGRect(0, 0, 40, 40);
            _addbutton.SetImage(UIImage.FromBundle("AddButton"), UIControlState.Normal);

            var _logoutButton = new UIButton(UIButtonType.Custom);
            _logoutButton.Frame = new CGRect(0, 0, 40, 40);
            _logoutButton.SetImage(UIImage.FromBundle("LogOutButton"), UIControlState.Normal);

            NavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] { new UIBarButtonItem(_logoutButton), new UIBarButtonItem(_addbutton) }, false);

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(43, 61, 80);

            _addbutton.TouchUpInside += AddButtonClick;
            _logoutButton.TouchUpInside += LogoutButtonClick;
            set.Apply();
        }

        private void LogoutButtonClick(object sender, EventArgs e)
        {
            ViewModel.LogOutUserCommand.Execute();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            ViewModel.ShowTaskChangedViewCommand.Execute();
        }
    }
}