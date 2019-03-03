using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace EnvironmentSwitcher.Windows
{
    class TrayElement
    {
        public TrayElement(Container components, ContextMenuStrip ItemsWindow)
        {
            new NotifyIcon(components)
            {
                ContextMenuStrip = ItemsWindow,
                Icon = ((Icon)(new ComponentResourceManager(typeof(MainWindow)).GetObject("TrayElement.Icon"))),
                Text = "Env switcher",
                Visible = true
            };
        }
    }
}
