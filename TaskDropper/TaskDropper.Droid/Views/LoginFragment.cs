using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TaskDropper.Core.Authentication;
using TaskDropper.Core.Services;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Activity(Label = "TaskDropper", MainLauncher = true)]
    public class LoginFragment : BaseFragment<GoogleLoginViewModel>, IGoogleAuthenticationDelegate
    {
        protected override int FragmentId => Resource.Layout.login_view;
        public static GoogleAuthenticator Auth;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl, this);

            var googleLoginButton = view.FindViewById<Button>(Resource.Id.googleLoginButton);
            googleLoginButton.Click += OnGoogleLoginButtonClicked;
            //Add font
            Typeface newTypeface = Typeface.CreateFromAsset(Activity.Assets, "NK123.otf");
            googleLoginButton.SetTypeface(newTypeface, TypefaceStyle.Normal);

            return view;
        }
        private void OnGoogleLoginButtonClicked(object sender, EventArgs e)
        {
            // Display the activity handling the authentication
            var authenticator = Auth.GetAuthenticator();
            var intent = authenticator.GetUI(this.Context);
            
            StartActivity(intent);
            ParentActivity.Finish();
        }

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {

            // Retrieve the user's email address
            var googleService = new GoogleService();
            var email = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);
            ViewModel.ShowHomeViewModelCommand.Execute(null);
            // Display it on the UI
            //var googleButton = FindViewById<Button>(Resource.Id.googleLoginButton);
            ViewModel.AddUserToTable(email);
            ViewModel.PrintLastUser();
            
            
            
        }

        public void OnAuthenticationCanceled()
        {
            try
            {
                new AlertDialog.Builder(this.Context)
                               .SetTitle("Authentication canceled")
                               .SetMessage("You didn't completed the authentication process")
                               .Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            new AlertDialog.Builder(this.Context)
                           .SetTitle(message)
                           .SetMessage(exception?.ToString())
                           .Show();
        }


    }
}
    
   

