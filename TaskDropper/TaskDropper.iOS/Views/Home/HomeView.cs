using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;
using TaskDropper.Core.ViewModels;
using UIKit;

namespace TaskDropper.iOS.Views
{
    public partial class HomeView : MvxTabBarViewController<HomeViewModel>
    {
        public HomeView() : base(nameof(HomeView), null)
        {
            tab1 = new TasksListView();
            tab1.Title = "List Task";
            tab1.ViewModel = ViewModel.TaskListViewModel;


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
            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(_addbutton), false);
            //set.Bind(_addbutton).To(m => m.ShowTaskChangedViewCommand);

            set.Apply();
        }
    }
}