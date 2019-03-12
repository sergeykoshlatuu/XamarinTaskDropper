using MvvmCross.Forms.Views;
using System;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace TaskDropper.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GoogleLoginPage : MvxContentPage<FormsLoginVieModel>
    {
        
        public static GoogleAuthenticator Auth;
        
        public GoogleLoginPage ()
		{
            try
            {
                InitializeComponent();
            } 
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
		}

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void GoogleLogin_Clicked(object sender, EventArgs e)
        {
            ViewModel.ShowGoogleLogin.Execute();
        }
    }
}