// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TaskDropper.iOS.Views
{
    [Register ("GoogleLoginView")]
    partial class GoogleLoginView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoogleLoginButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GoogleLoginButton != null) {
                GoogleLoginButton.Dispose ();
                GoogleLoginButton = null;
            }
        }
    }
}