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
    [Register ("CalculateViewController")]
    partial class CalculateViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField WaterTxtInput { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (WaterTxtInput != null) {
                WaterTxtInput.Dispose ();
                WaterTxtInput = null;
            }
        }
    }
}