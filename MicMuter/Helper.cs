using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace MicMuter
{
    public static class Helper
    {
        public static string GetApplicationVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version.ToString(3);
        }
        
        public static void VisitWebsite()
        {
            Process.Start(new ProcessStartInfo { FileName = Configuration.AppWebsite, UseShellExecute = true });
        }

        public static string GetStatusDescription(MicrophoneStatus status)
        {
            if (status == MicrophoneStatus.NotInUse)
            {
                return "No microphone is currently in use.";
            }
            else if (status == MicrophoneStatus.Muted)
            {
                return "Your microphone is currently muted.";
            }
            else
            {
                return "Your microphone is currently unmuted.";
            }
        }

        public static string GetHotKeyDescription(ModifierKeys modifier, Keys key)
        {
            var description = key.ToString();
            if (modifier != ModifierKeys.None)
            {
                description = modifier.ToString().Replace(", ", "+") + "+" + description;
            }
            return description;
        }
    }
}