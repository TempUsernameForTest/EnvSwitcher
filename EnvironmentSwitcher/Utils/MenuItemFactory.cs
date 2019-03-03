using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EnvironmentSwitcher.Windows;

namespace EnvironmentSwitcher.Utils
{
    public class SectionFactory
    {
        //public static ToolStripItem[] InitializeSection<T>(bool temp)
        //{
        //    var elements = new List<ToolStripItem>();

        //    var a = new T();

        //    return elements.ToArray();
        //}

        [Obsolete]
        public static ToolStripItem[] InitializeSection<T>()
        {
            var elements = new List<ToolStripItem>();

            foreach (var property in typeof(T).GetProperties())
            {
                var y = Activator.CreateInstance(property.PropertyType) as ToolStripItem;

                if (property.GetCustomAttributes(typeof(MenuItemAttribute), false).Length != 0)
                {
                    var attr = ((MenuItemAttribute)property.GetCustomAttributes(false).First());
                    y.Text = attr.Text;

                    if (attr.FontStyle != FontStyle.Regular)
                        y.Font = new Font("Segoe UI", 9F, attr.FontStyle);

                    if (y is ToolStripMenuItem)
                        y.Click += EventHandlers.ChangeColor;

                    if (attr.Text == MainWindow.CurrentEnvironment)
                    {
                        EventHandlers.CheckedItem = (ToolStripMenuItem)y;
                        y.BackColor = SystemColors.AppWorkspace;
                    }
                }

                elements.Add(y);
            }

            return elements.ToArray();
        }
    }
}
