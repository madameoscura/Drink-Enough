using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Drink_Enough
{
    class NamedValue<A>
    {
        public string Name { get; set; }
        public A Value { get; set; }

        public NamedValue(string name, A value)
        {
            Name = name;
            Value = value;
        }
    }

    class PickerDataModel<A> : UIPickerViewModel
    {
        //set up model to use in PickerView in WaterIntakeVC
        public event EventHandler<EventArgs> ValueChanged;
        int SelectedIndex;
        public IList<NamedValue<A>> Items { private set; get; }

        public PickerDataModel()
        {
            Items = new List<NamedValue<A>>();


        }

        public NamedValue<A> SelectedItem
        {
            get
            {
                return Items != null &&
                    SelectedIndex >= 0 &&
                    SelectedIndex < Items.Count ? Items[SelectedIndex] : null;
            }
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Items != null ? Items.Count : 0;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return Items != null && Items.Count > row ? Items[(int)row].Name : null;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            SelectedIndex = (int)row;
            ValueChanged?.Invoke(this, new EventArgs());
        }
    }


}