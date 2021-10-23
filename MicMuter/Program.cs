using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MicMuter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var monitor = new TrayMonitor())
            {
                Application.Run();
            }
        }

        public static void VisitWebsite()
        {
            Process.Start(new ProcessStartInfo { FileName = Configuration.AppWebsite, UseShellExecute = true });
        }
    }
}