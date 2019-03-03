using System;
using System.Windows.Forms;
using EnvironmentSwitcher.Windows;

namespace EnvironmentSwitcher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
