using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace EnvironmentSwitcher.Windows
{
    public partial class MainWindow : Form
    {
        private Container components;
        public static ContextMenuStrip ItemsWindow;
        public static string CurrentEnvironment;

        public static string PathToAppConfig
        {
            get => Properties.Settings.Default.AppSettingsPath;

            set
            {
                Properties.Settings.Default.AppSettingsPath = value;
                Properties.Settings.Default.Save();
            }
        }

        public MainWindow()
        {
            //dublicate
            if (PathToAppConfig == string.Empty)
            {
                AlertWindows.ShowFileNotSetPopUp();
            }
            else
            {
                ReadAppConfig();
            }

            components = new Container();
            ItemsWindow = new ItemsWindow(components);
            new TrayElement(components, ItemsWindow);

            SuspendLayout();

            Enabled = false;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            ResumeLayout(false);
        }

        private void ReadAppConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader(PathToAppConfig))
                {
                    var text = sr.ReadToEnd(); //wtf is ReadToEndAsync
                    var xml = XDocument.Parse(text);
                    CurrentEnvironment = (from el in xml.Element("configuration").Element("appSettings").Elements("add")
                                          where el.Attribute("key").Value == "Environment"
                                          select el).Single().Attribute("value").Value;
                }
            }
            catch (FileNotFoundException)
            {
                AlertWindows.ShowFileNotFoundPopUp();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //        components.Dispose();

        //    base.Dispose(disposing);
        //}
    }
}
