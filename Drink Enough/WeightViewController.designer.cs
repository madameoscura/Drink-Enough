// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Drink_Enough
{
    [Register ("WeightViewController")]
    partial class WeightViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton WeightIntakeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField WeightTxtInput { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (WeightIntakeButton != null) {
                WeightIntakeButton.Dispose ();
                WeightIntakeButton = null;
            }

            if (WeightTxtInput != null) {
                WeightTxtInput.Dispose ();
                WeightTxtInput = null;
            }
        }
    }
}