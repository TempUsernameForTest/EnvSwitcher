using System.Windows.Forms;
using EnvironmentSwitcher.Utils;

namespace EnvironmentSwitcher.MenuSections
{
    public class DefaultSection
    {
        [MenuItem("Options")]
        public ToolStripMenuItem Options { get; set; }

        [MenuItem("Exit")]
        public ToolStripMenuItem Exit { get; set; }
    }
}
