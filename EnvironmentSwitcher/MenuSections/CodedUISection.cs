using System.Drawing;
using System.Windows.Forms;
using EnvironmentSwitcher.Utils;

namespace EnvironmentSwitcher.MenuSections
{
    public class CodedUISection
    {
        [MenuItem("Coded UI", FontStyle.Bold)]
        public ToolStripLabel Label { get; set; }

        [MenuItem("Baml")]
        public ToolStripMenuItem Baml { get; set; }

        [MenuItem("Seb")]
        public ToolStripMenuItem Seb { get; set; }

        [MenuItem("Lloyds")]
        public ToolStripMenuItem Lloyds { get; set; }

        public ToolStripSeparator Separator { get; set; }
    }
}
