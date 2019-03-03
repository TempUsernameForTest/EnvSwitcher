using System.Drawing;
using System.Windows.Forms;
using EnvironmentSwitcher.Utils;

namespace EnvironmentSwitcher.MenuSections
{
    public class QXsSection
    {
        [MenuItem("QXs", FontStyle.Bold)]
        public ToolStripLabel Label { get; set; }

        [MenuItem("QX 1")]
        public ToolStripMenuItem Qx1 { get; set; }

        [MenuItem("QX 2")]
        public ToolStripMenuItem Qx2 { get; set; }

        [MenuItem("QX 3")]
        public ToolStripMenuItem Qx3 { get; set; }

        public ToolStripSeparator Separator { get; set; }
    }
}
