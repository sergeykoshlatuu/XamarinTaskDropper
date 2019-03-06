using MvvmCross.Forms.Views;
using System;
using Xamarin.Auth;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UIKit;
using TaskDropper.Core.Services;

namespace TaskDropper.Forms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GoogleLoginPage : MvxContentPage<GoogleLoginViewModel>
    {
        GoogleOAuthToken _token = null;
        public static GoogleAuthenticator Auth;
        
        public GoogleLoginPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

        private void GoogleLogin_Clicked(object sender, EventArgs e)
        {
            LoginView.IsVisible = true;
        }
    }
}