using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Drink_Enough
{
    class TableSource: UITableViewSource
    {
        List<Drink> drinkList = new List<Drink>();
        string CellIdentifier = "TableCell";
        HistoryTableViewController viewController;

        public TableSource(List<Drink> drinkList, HistoryTableViewController viewController)
        {
            this.drinkList = drinkList;
            this.viewController = viewController;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
            }

            cell.TextLabel.Text = drinkList[indexPath.Row].AmountDrank.ToString();
            cell.DetailTextLabel.Text = drinkList[indexPath.Row].CreateDate.ToString();

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return drinkList.Count;
        }      

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false; 
        }
    }
}