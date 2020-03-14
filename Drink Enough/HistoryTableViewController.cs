using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Drink_Enough
{
    public partial class HistoryTableViewController : UITableViewController
    {
        List<Drink> drinkList = new List<Drink>();
        DBHelper dBHelper = new DBHelper();
        JsonHelper jsonHelper = new JsonHelper();

        public HistoryTableViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            drinkList = dBHelper.getAllDrinks();
            HistoryTableView.Source = new TableSource(drinkList, this);
            HistoryTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            drinkList = dBHelper.getAllDrinks();
            HistoryTableView.Source = new TableSource(drinkList, this);
            HistoryTableView.ReloadData();
        }
    }
}