using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class XmlSettingListBoxItem
{
    //private string _text, _desc;
    //private bool _value;

    public XmlSettingListBoxItem(string text, bool value, string description)
    {
        Text = text;
        Value = value;
        Description = description;
    }

    public string Text { get; set; }
    public bool Value { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return Text + ": " + Description;
    }
}