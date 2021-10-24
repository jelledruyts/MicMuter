using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMuter
{
    public class Configuration
    {
        #region Constants

        public const string AppName = "MicMuter";
        public const string AppWebsite = "https://github.com/jelledruyts/MicMuter";
        private const string ConfigurationRootKey = @"SOFTWARE\" + AppName;
        // Default shortcut is "Windows+Shift+A" like Powertoys (https://docs.microsoft.com/en-us/windows/powertoys/video-conference-mute).
        private const ModifierKeys defaultMicrophoneToggleHotKeyModifier = (ModifierKeys.Win | ModifierKeys.Shift);
        private const Keys defaultMicrophoneToggleHotKey = Keys.A;
        private const ModifierKeys defaultMicrophoneMuteHotKeyModifier = ModifierKeys.None;
        private const Keys defaultMicrophoneMuteHotKey = Keys.None;
        private const ModifierKeys defaultMicrophoneUnmuteHotKeyModifier = ModifierKeys.None;
        private const Keys defaultMicrophoneUnmuteHotKey = Keys.None;
        private const bool defaultRunOnStartup = false;

        #endregion

        #region Properties

        public bool IsFirstRun { get; set; }
        public bool RunOnStartup { get; set; }
        public ModifierKeys MicrophoneToggleHotKeyModifier { get; set; }
        public Keys MicrophoneToggleHotKey { get; set; }
        public ModifierKeys MicrophoneMuteHotKeyModifier { get; set; }
        public Keys MicrophoneMuteHotKey { get; set; }
        public ModifierKeys MicrophoneUnmuteHotKeyModifier { get; set; }
        public Keys MicrophoneUnmuteHotKey { get; set; }

        #endregion

        #region Load

        public static Configuration Load()
        {
            using (var rootKey = Registry.CurrentUser.OpenSubKey(ConfigurationRootKey))
            {
                var configuration = new Configuration();
                configuration.IsFirstRun = rootKey == null;
                configuration.RunOnStartup = GetIntValue(rootKey, nameof(configuration.RunOnStartup), defaultRunOnStartup ? 1 : 0) != 0;
                configuration.MicrophoneToggleHotKeyModifier = (ModifierKeys)GetIntValue(rootKey, nameof(configuration.MicrophoneToggleHotKeyModifier), (int)defaultMicrophoneToggleHotKeyModifier);
                configuration.MicrophoneToggleHotKey = (Keys)GetIntValue(rootKey, nameof(configuration.MicrophoneToggleHotKey), (int)defaultMicrophoneToggleHotKey);
                configuration.MicrophoneMuteHotKeyModifier = (ModifierKeys)GetIntValue(rootKey, nameof(configuration.MicrophoneMuteHotKeyModifier), (int)defaultMicrophoneMuteHotKeyModifier);
                configuration.MicrophoneMuteHotKey = (Keys)GetIntValue(rootKey, nameof(configuration.MicrophoneMuteHotKey), (int)defaultMicrophoneMuteHotKey);
                configuration.MicrophoneUnmuteHotKeyModifier = (ModifierKeys)GetIntValue(rootKey, nameof(configuration.MicrophoneUnmuteHotKeyModifier), (int)defaultMicrophoneUnmuteHotKeyModifier);
                configuration.MicrophoneUnmuteHotKey = (Keys)GetIntValue(rootKey, nameof(configuration.MicrophoneUnmuteHotKey), (int)defaultMicrophoneUnmuteHotKey);
                return configuration;
            }
        }

        private static int GetIntValue(RegistryKey rootKey, string name, int defaultValue)
        {
            if (rootKey != null)
            {
                var value = rootKey.GetValue(name);
                if (value != null)
                {
                    return (int)value;
                }
            }
            return defaultValue;
        }

        #endregion

        #region Save

        public static void Save(Configuration configuration)
        {
            if (configuration != null)
            {
                using (var rootKey = Registry.CurrentUser.CreateSubKey(ConfigurationRootKey))
                {
                    rootKey.SetValue(nameof(configuration.RunOnStartup), configuration.RunOnStartup ? 1 : 0, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneToggleHotKeyModifier), configuration.MicrophoneToggleHotKeyModifier, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneToggleHotKey), configuration.MicrophoneToggleHotKey, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneMuteHotKeyModifier), configuration.MicrophoneMuteHotKeyModifier, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneMuteHotKey), configuration.MicrophoneMuteHotKey, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneUnmuteHotKeyModifier), configuration.MicrophoneUnmuteHotKeyModifier, RegistryValueKind.DWord);
                    rootKey.SetValue(nameof(configuration.MicrophoneUnmuteHotKey), configuration.MicrophoneUnmuteHotKey, RegistryValueKind.DWord);
                }
            }
        }

        #endregion

        #region Remove

        public static void Remove()
        {
            Registry.CurrentUser.DeleteSubKeyTree(ConfigurationRootKey, false);
        }

        #endregion
    }
}