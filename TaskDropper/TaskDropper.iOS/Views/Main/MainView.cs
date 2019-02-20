using Foundation;
using MvvmCross.Platforms.Ios.Views;
using System;
using TaskDropper.Core.ViewModels;
using UIKit;

namespace TaskDropper.iOS.Views
{
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView() : base(nameof(MainView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (!ViewModel.IsUserLogin())
            {
                ViewModel.ShowGoogleLoginViewModelCommand.Execute(null);
            }
            else
            {
                ViewModel.ShowHomeViewModelCommand.Execute(null);
            }
        }
    }
}