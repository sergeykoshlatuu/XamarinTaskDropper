using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Services;
using TaskDropper.Forms.iOS.PageRenderers;
using TaskDropper.Forms.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(LoginPage), typeof(GoogleLoginRenderer))]
namespace TaskDropper.Forms.iOS.PageRenderers
{
    public class GoogleLoginRenderer : PageRenderer, IGoogleAuthenticationDelegate
    {
        IDatabaseUserService _databaseUserService = Mvx.IoCProvider.Resolve<IDatabaseUserService>();
        public static GoogleAuthenticator Auth;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            
        }

        public async override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl, this);
            var authentificator = Auth.GetAuthenticator();
            var viewController = authentificator.GetUI();
            await PresentViewControllerAsync(viewController, false);
        }

        public void OnAuthenticationCanceled()
        {
            DismissViewController(true, null);
            MessagingCenter.Send<Page>((Page)this.Element, "Canceled");
        }

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            DismissViewController(true, null);
            var googleService = new GoogleService();
            var email = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);

            MessagingCenter.Send<Page>((Page)this.Element, "Complete");
            AddUserToTable(email);
        }

         public void AddUserToTable(string email)
        {
            _databaseUserService.AddUserToTable(email);
            _databaseUserService.UpdateLastUser(email);
        }
        public void OnAuthenticationFailed(string message, Exception exception)
        {
            DismissViewController(true, null);
            MessagingCenter.Send<Page>((Page)this.Element, "Failed");

        }
    }
}