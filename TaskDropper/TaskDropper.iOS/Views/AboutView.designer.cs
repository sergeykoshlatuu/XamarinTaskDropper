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
    [Register ("AboutView")]
    partial class AboutView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView nameTextView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (nameTextView != null) {
                nameTextView.Dispose ();
                nameTextView = null;
            }
        }
    }
}