using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using EnvironmentSwitcher.Windows;
using System.Linq;


namespace EnvironmentSwitcher.Utils
{
    public class EventHandlers
    {
        public static ToolStripMenuItem CheckedItem;

        public static EventHandler ChangeColor => new EventHandler(CheckMenuItem);
        public static EventHandler OpenOptionsWindow => new EventHandler(ShowOptions);
        public static EventHandler HideItemsWindow => new EventHandler(CloseItemsWindow);
        public static EventHandler ExitApplication => new EventHandler(ExitApp);

        private static void ShowOptions(object sender, EventArgs e)
        {
            //new OptionsWindow().Show();

            var openFileWindow = new OpenFileDialog()
            {
                InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}",  //MyComputer
                Filter  = "App.config|App.config",
            };

            if (openFileWindow.ShowDialog() == DialogResult.OK)
                MainWindow.PathToAppConfig = openFileWindow.FileName;

            openFileWindow.Dispose();
        }

        private static void CloseItemsWindow(object sender, EventArgs e)
        {
            MainWindow.ItemsWindow.Close();
        }

        private static void ExitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void CheckMenuItem(object sender, EventArgs e)
        {
            MainWindow.ItemsWindow.SuspendLayout();

            CheckedItem.BackColor = SystemColors.Control;
            CheckedItem = ((ToolStripMenuItem)sender);
            CheckedItem.BackColor = SystemColors.AppWorkspace;

            var env = CheckedItem.GetType();

            //dublicate
            try
            {
                using (StreamReader sr = new StreamReader(MainWindow.PathToAppConfig))
                {
                    var text = sr.ReadToEnd(); //wtf is ReadToEndAsync
                    var xml = XDocument.Parse(text);
                    var a = (from el in xml.Element("configuration").Element("appSettings").Elements("add")
                                          where el.Attribute("key").Value == "Environment"
                                          select el).Single().Attribute("value").Value;
                }
            }
            catch (FileNotFoundException)
            {
                AlertWindows.ShowFileNotFoundPopUp();
            }

            MainWindow.ItemsWindow.ResumeLayout();
        }
    }
}
