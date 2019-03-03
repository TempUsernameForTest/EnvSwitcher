using System;
using System.Drawing;

namespace EnvironmentSwitcher.Utils
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string text)
        {
            Text = text;
        }

        public MenuItemAttribute(string text, FontStyle fontStyle)
        {
            Text = text;
            FontStyle = fontStyle;
        }

        public string Text { get; set; }

        public FontStyle FontStyle { get; set; }
    }
}
