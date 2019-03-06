using System;
using Android.App;
using Android.Content;
using MvvmCross;
using MvvmCross.Navigation;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Services;
using TaskDropper.Core.ViewModels;
using TaskDropper.Forms.CustomControls;
using TaskDropper.Forms.Droid.PageRenderers;
using TaskDropper.Forms.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(View), typeof(GoogleLoginRenderer))] 
namespace TaskDropper.Forms.Droid.PageRenderers
{
    public class GoogleLoginRenderer : ViewRenderer , IGoogleAuthenticationDelegate
    {
        public IMvxNavigationService navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        public IDatabaseUserService userService = Mvx.IoCProvider.Resolve<IDatabaseUserService>();
        
        public GoogleLoginRenderer(Context context) : base(context)
        {

        }

        bool done = false;
        public static GoogleAuthenticator Auth;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (!done)
            {
                Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl,this);

                var activity = this.Context as Activity;
                var authenticator = Auth.GetAuthenticator();
                var intent = authenticator.GetUI(this.Context);
               
                activity.StartActivity(intent);
                done = true;
            }

            e.NewElement.PropertyChanged += NewElement_PropertyChanged;
        }

        private void NewElement_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if(e.PropertyName=="MyPropertyName")
            {
                ((LoginView)sender).
            }
            throw new NotImplementedException();
        }

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            GoogleLoginViewModel GoogleLoginViewModel = new GoogleLoginViewModel(navigationService, userService);
            var googleService = new GoogleService();
            var email = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);

            GoogleLoginViewModel.ShowHomeViewModelCommand.Execute(null);
            GoogleLoginViewModel.AddUserToTable(email);
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        { 

        }

        public void OnAuthenticationCanceled()
        {
           
        }
    }
}
