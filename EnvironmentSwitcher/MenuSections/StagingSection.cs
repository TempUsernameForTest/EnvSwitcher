using System.Drawing;
using System.Windows.Forms;
using EnvironmentSwitcher.Utils;

namespace EnvironmentSwitcher.MenuSections
{
    public class StagingSection
    {
        [MenuItem("Stagings", FontStyle.Bold)]
        public ToolStripLabel Label { get; set; }

        [MenuItem("Staging 1")]
        public ToolStripMenuItem Staging1 { get; set; }

        [MenuItem("Staging 2")]
        public ToolStripMenuItem Staging2 { get; set; }

        [MenuItem("Staging 3")]
        public ToolStripMenuItem Staging3 { get; set; }

        public ToolStripSeparator Separator { get; set; }
    }
}
