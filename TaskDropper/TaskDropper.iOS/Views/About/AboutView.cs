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

            SetBind();
        }

        private void SetBind()
        {
            var set = this.CreateBindingSet<AboutView, AboutViewModel>();
            set.Bind(NameLabel).To(vm => vm.Name);
            set.Bind(EmailLabel).To(vm => vm.Email);
            set.Bind(NoInternetConnection).For(v => v.Hidden).To(vm => vm.IsNoInternetVisible);
            set.Apply();
        }
    }
}