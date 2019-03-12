using System;
using Android.App;
using Android.Content;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Services;
using TaskDropper.Core.ViewModels;

using TaskDropper.Forms.Droid.PageRenderers;
using TaskDropper.Forms.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(GoogleLoginRenderer))] 
namespace TaskDropper.Forms.Droid.PageRenderers
{
    public class GoogleLoginRenderer : PageRenderer , IGoogleAuthenticationDelegate
    {
       
        IDatabaseUserService _databaseUserService = Mvx.IoCProvider.Resolve<IDatabaseUserService>();
        bool done = false;
        public static GoogleAuthenticator Auth;
        public GoogleLoginRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
           
            if (!done)
            {
                Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl, this);
                
                var activity = this.Context as Activity;
                var authenticator = Auth.GetAuthenticator();
                var intent = authenticator.GetUI(this.Context);

                activity.StartActivity(intent);
                WebView webView = new WebView();
                done = true;     
            }
        }
       

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            var googleService = new GoogleService();
            var email = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);
            AddUserToTable(email);
            MessagingCenter.Send<Page>(this.Element, "Complete");
           
        }

        public void AddUserToTable(string email)
        {
            _databaseUserService.AddUserToTable(email);
            _databaseUserService.UpdateLastUser(email);
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            MessagingCenter.Send<Page>(this.Element, "Failed");
        }

        public void OnAuthenticationCanceled()
        {
            MessagingCenter.Send<Page>(this.Element, "Canceled");
        }
       
    }
}
