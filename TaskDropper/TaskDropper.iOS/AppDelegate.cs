using Foundation;
using MvvmCross.Platforms.Ios.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using TaskDropper.Core;
using TaskDropper.iOS.Views;
using UIKit;

namespace TaskDropper.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        public override UIWindow Window { get; set; }

        // FinishedLaunching is the very first code to be executed in your app. Don't forget to call base!
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            return result;
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            // Convert iOS NSUrl to C#/netxf/BCL System.Uri - common API
            var uri_netfx = new Uri(url.AbsoluteString);

            GoogleLoginView.Auth?.OnPageLoading(uri_netfx);
            
            return true;
        }

       
    }
}