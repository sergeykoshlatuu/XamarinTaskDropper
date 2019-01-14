using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TaskDropper.Droid
{
    public static class Configuration
    {
        public const string ClientId = "1060051282932-i65td79df9mqhurs3qlegk5ncnh1hikr.apps.googleusercontent.com";
        public const string Scope = "email";
        public const string RedirectUrl = "com.koshsy6363.xamarin:/oauth2redirect";
    }
}