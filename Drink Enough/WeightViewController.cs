using Foundation;
using System;
using UIKit;

namespace Drink_Enough
{
    public partial class WeightViewController : UIViewController
    {
       
        public WeightViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
        }

        
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var Controller = segue.DestinationViewController
                as CalculateViewController;

            if (Controller != null)
            {
                //I defined UserData early in my code and 
                //I have SentData defined in the FriendsTabViewController  
                Controller.userData = WeightTxtInput.Text;
            }
        }
    }
}