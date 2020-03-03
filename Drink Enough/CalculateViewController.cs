using Foundation;
using System;
using UIKit;

namespace Drink_Enough
{
    public partial class CalculateViewController : UIViewController
    {
        public string userData { get; set; }
        public CalculateViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            WaterTxtInput.Text = userData;

        }
    }
}