using System.Windows.Forms;
using System.ComponentModel;
using EnvironmentSwitcher.Utils;
using EnvironmentSwitcher.MenuSections;

namespace EnvironmentSwitcher.Windows
{
    class ItemsWindow : ContextMenuStrip
    {
        public ItemsWindow(Container components) : base(components)
        {
            SuspendLayout();

            AutoClose = false;
            ShowImageMargin = false;
            MouseLeave += EventHandlers.HideItemsWindow;

            InitElements();

            ResumeLayout(false);
        }

        private void InitElements()
        {
            var codedUI = SectionFactory.InitializeSection<CodedUISection>();
            var qXs = SectionFactory.InitializeSection<QXsSection>();
            var staging = SectionFactory.InitializeSection<StagingSection>();

            ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem();
            ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem();

            Items.AddRange(codedUI);
            Items.AddRange(qXs);
            Items.AddRange(staging);

            if (MainWindow.PathToAppConfig == string.Empty)
            {
                foreach (ToolStripItem item in Items)
                {
                    item.Enabled = false;
                }
            }

            toolStripMenuItem13.Text = "Options";
            toolStripMenuItem13.Click += EventHandlers.OpenOptionsWindow;

            toolStripMenuItem14.Text = "Exit";
            toolStripMenuItem14.Click += EventHandlers.ExitApplication;
            Items.AddRange(new ToolStripItem[] { toolStripMenuItem13, toolStripMenuItem14 });
        }
    }
}
