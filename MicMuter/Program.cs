using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MicMuter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Logger.LogMessage(TraceEventType.Information, $"{Configuration.AppName} v{Helper.GetApplicationVersion()} started");
            var requestedAction = ParseCommandLine(args);
            if (requestedAction != MicrophoneAction.None)
            {
                // A command-line action was requested, only perform that and exit.
                Logger.LogMessage(TraceEventType.Information, $"Performing command-line requested action \"{requestedAction}\" and exiting");
                using (var controller = new MicrophoneController())
                {
                    controller.PerformAction(requestedAction);
                }
            }
            else
            {
                // No command-line action was requested, start the application normally.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (var monitor = new TrayMonitor())
                {
                    Application.Run();
                }
            }
            Logger.LogMessage(TraceEventType.Information, $"{Configuration.AppName} v{Helper.GetApplicationVersion()} exited");
        }

        private static MicrophoneAction ParseCommandLine(string[] args)
        {
            // Check if any command-line argument is passed as "/<action>", e.g. "/toggle".
            foreach (var action in Enum.GetValues(typeof(MicrophoneAction)).Cast<MicrophoneAction>())
            {
                if (args.Contains("/" + action, StringComparer.InvariantCultureIgnoreCase))
                {
                    return action;
                }
            }
            return MicrophoneAction.None;
        }
    }
}