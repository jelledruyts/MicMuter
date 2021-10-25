using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;

namespace MicMuter
{
    public class MicrophoneController : IDisposable
    {
        private ICollection<MMDevice> microphoneDevices = null;

        public event EventHandler OnMicrophoneStateChanged;

        public MicrophoneController()
        {
            RefreshMicrophoneDevices();
        }

        private void RefreshMicrophoneDevices()
        {
            DisposeMicrophoneDevices();
            Logger.LogMessage(TraceEventType.Verbose, $"Enumerating microphone devices...");
            using (var enumerator = new MMDeviceEnumerator())
            {
                this.microphoneDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToArray();
                foreach (var microphoneDevice in this.microphoneDevices)
                {
                    Logger.LogMessage(TraceEventType.Verbose, $"Found device \"{microphoneDevice.FriendlyName}\"");
                    microphoneDevice.AudioEndpointVolume.OnVolumeNotification += MicrophoneStateChanged;
                }
            }
        }

        private void MicrophoneStateChanged(AudioVolumeNotificationData e)
        {
            Logger.LogMessage(TraceEventType.Verbose, $"Microphone state changed");
            // Allow the OS microphone status to settle before raising the notification.
            Thread.Sleep(100);
            this.OnMicrophoneStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            DisposeMicrophoneDevices();
        }

        private void DisposeMicrophoneDevices()
        {
            if (this.microphoneDevices != null)
            {
                Logger.LogMessage(TraceEventType.Verbose, $"Disposing microphone devices...");
                foreach (var microphoneDevice in this.microphoneDevices)
                {
                    microphoneDevice.AudioEndpointVolume.OnVolumeNotification -= MicrophoneStateChanged;
                    microphoneDevice.Dispose();
                    Logger.LogMessage(TraceEventType.Verbose, $"Disposed device \"{microphoneDevice.FriendlyName}\"");
                }
                this.microphoneDevices = null;
            }
        }

        public MicrophoneStatus GetStatus()
        {
            // Check if ANY microphone is actively being used in an audio session, and if so whether it is muted or not.
            Logger.LogMessage(TraceEventType.Verbose, $"Checking microphone status...");
            var microphones = GetMicrophones();
            var status = MicrophoneStatus.NotInUse;
            if (microphones.Any(m => m.Status == MicrophoneStatus.Unmuted))
            {
                status = MicrophoneStatus.Unmuted;
            }
            if (microphones.Any(m => m.Status == MicrophoneStatus.Muted))
            {
                status = MicrophoneStatus.Muted;
            }
            Logger.LogMessage(TraceEventType.Verbose, $"Current microphone status: {status}");
            return status;
        }

        public ICollection<Microphone> GetMicrophones()
        {
            var output = new List<Microphone>(this.microphoneDevices.Count);
            foreach (var microphoneDevice in this.microphoneDevices)
            {
                Logger.LogMessage(TraceEventType.Verbose, $"Checking device \"{microphoneDevice.FriendlyName}\"...");
                // Check if the microphone is actively being used in an audio session.
                var status = MicrophoneStatus.NotInUse;
                microphoneDevice.AudioSessionManager.RefreshSessions();
                for (var i = 0; i < microphoneDevice.AudioSessionManager.Sessions.Count; i++)
                {
                    var session = microphoneDevice.AudioSessionManager.Sessions[i];
                    Logger.LogMessage(TraceEventType.Verbose, $"Audio session {1}: state={session.State}, mute={session.SimpleAudioVolume.Mute}");
                    if (session.State == AudioSessionState.AudioSessionStateActive)
                    {
                        // The microphone is in an active audio session; check whether it's muted or not.
                        if (status == MicrophoneStatus.NotInUse)
                        {
                            status = MicrophoneStatus.Muted;
                        }
                        if (!session.SimpleAudioVolume.Mute)
                        {
                            // The microphone is actively being used and not muted.
                            status = MicrophoneStatus.Unmuted;
                        }
                    }
                }
                Logger.LogMessage(TraceEventType.Verbose, $"Device status for \"{microphoneDevice.FriendlyName}\": {status}");
                output.Add(new Microphone { FriendlyName = microphoneDevice.FriendlyName, Status = status });
            }
            return output;
        }

        public void Mute()
        {
            PerformAction(MicrophoneAction.Mute);
        }

        public void Unmute()
        {
            PerformAction(MicrophoneAction.Unmute);
        }

        public bool Toggle()
        {
            return PerformAction(MicrophoneAction.Toggle);
        }

        public bool PerformAction(MicrophoneAction action)
        {
            Logger.LogMessage(TraceEventType.Information, $"Performing requested action \"{action}\"...");
            var shouldMute = (action == MicrophoneAction.Mute ? true : false);
            if (action == MicrophoneAction.Toggle)
            {
                var currentStatus = GetStatus();
                if (currentStatus == MicrophoneStatus.NotInUse)
                {
                    // If no mic is in use, take the mute status of the FIRST device.
                    if (this.microphoneDevices.Any())
                    {
                        var firstDeviceMuted = this.microphoneDevices.First().AudioEndpointVolume.Mute;
                        Logger.LogMessage(TraceEventType.Verbose, $"Toggle requested while not in use and first device is {(firstDeviceMuted ? "muted" : "unmuted")}");
                        shouldMute = !firstDeviceMuted;
                    }
                }
                else
                {
                    // If any mic is in use, take the overall mute status across all microphones.
                    Logger.LogMessage(TraceEventType.Verbose, $"Toggle requested while in use and current status is \"{currentStatus}\"");
                    shouldMute = currentStatus == MicrophoneStatus.Muted ? false : true;
                }
            }
            Logger.LogMessage(TraceEventType.Verbose, $"Setting all devices to {(shouldMute ? "muted" : "unmuted")}...");
            foreach (var microphoneDevice in this.microphoneDevices)
            {
                Logger.LogMessage(TraceEventType.Verbose, $"Setting device \"{microphoneDevice.FriendlyName}\" to {(shouldMute ? "muted" : "unmuted")}...");
                microphoneDevice.AudioEndpointVolume.Mute = shouldMute;
            }
            return shouldMute;
        }
    }
}