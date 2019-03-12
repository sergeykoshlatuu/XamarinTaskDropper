using MvvmCross.Forms.Views;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace TaskDropper.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutView : MvxContentPage<AboutViewModel>
	{
		public AboutView ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        { 
            base.OnAppearing();
        }
    }
}