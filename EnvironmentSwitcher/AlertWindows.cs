using System.Windows.Forms;
using EnvironmentSwitcher.Windows;

namespace EnvironmentSwitcher
{
    public class AlertWindows
    {
        private static readonly string AppName = "Environment Switcher";

        private static readonly string FileNotFoundMessage = 
            "'App.config' was not found at the given location:" + 
            "\n" + MainWindow.PathToAppConfig;

        private static readonly string FileNotSetMessage =
            "'App.config' location is not set" +
            "\n\n" +
            "Please," + "\n" +
            "specify 'App.config' location" + "\n" +
            "of 'Ipreo.FI.IssueBook.Tests'" + "\n" +
            "solution in 'Options' menu.";

        public static void ShowFileNotFoundPopUp()
        {
            MessageBox.Show(FileNotFoundMessage, AppName, MessageBoxButtons.OK);
        }

        public static void ShowFileNotSetPopUp()
        {
            MessageBox.Show(FileNotSetMessage, AppName, MessageBoxButtons.OK);
        }
    }
}
