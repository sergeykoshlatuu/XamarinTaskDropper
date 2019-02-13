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
    [Register ("TaskChangedView")]
    partial class TaskChangedView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DescriptionTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch StatusSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TitleTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DeleteButton != null) {
                DeleteButton.Dispose ();
                DeleteButton = null;
            }

            if (DescriptionTextField != null) {
                DescriptionTextField.Dispose ();
                DescriptionTextField = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }

            if (StatusSwitch != null) {
                StatusSwitch.Dispose ();
                StatusSwitch = null;
            }

            if (TitleTextField != null) {
                TitleTextField.Dispose ();
                TitleTextField = null;
            }
        }
    }
}