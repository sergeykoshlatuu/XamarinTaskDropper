using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.iOS.Views
{
    public partial class AboutView : MvxViewController<AboutViewModel>
    {
        public AboutView() : base(nameof(AboutView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<AboutView, AboutViewModel>();
            set.Bind(nameTextView).To(vm => vm.Name);
            //set.Bind(SubTotalTextField).To(vm => vm.Email);
            
            set.Apply();

            // this is optional. What this code does is to close the keyboard whenever you 
            // tap on the screen, outside the bounds of the TextField
          
        }
    }
}