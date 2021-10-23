using System;
using System.Collections.Generic;
using System.Linq;
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
            using (var enumerator = new MMDeviceEnumerator())
            {
                this.microphoneDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToArray();
                foreach (var microphoneDevice in this.microphoneDevices)
                {
                    microphoneDevice.AudioEndpointVolume.OnVolumeNotification += MicrophoneStateChanged;
                }
            }
        }

        private void MicrophoneStateChanged(AudioVolumeNotificationData e)
        {
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
                foreach (var microphoneDevice in this.microphoneDevices)
                {
                    microphoneDevice.AudioEndpointVolume.OnVolumeNotification -= MicrophoneStateChanged;
                    microphoneDevice.Dispose();
                }
                this.microphoneDevices = null;
            }
        }

        public MicrophoneStatus GetStatus()
        {
            // Check if ANY microphone is actively being used in an audio session, and if so whether it is muted or not.
            var microphones = GetMicrophones();
            if (microphones.Any(m => m.Status == MicrophoneStatus.Unmuted))
            {
                return MicrophoneStatus.Unmuted;
            }
            if (microphones.Any(m => m.Status == MicrophoneStatus.Muted))
            {
                return MicrophoneStatus.Muted;
            }
            return MicrophoneStatus.NotInUse;
        }

        public ICollection<Microphone> GetMicrophones()
        {
            var output = new List<Microphone>(this.microphoneDevices.Count);
            foreach (var microphoneDevice in this.microphoneDevices)
            {
                // Check if the microphone is actively being used in an audio session.
                var status = MicrophoneStatus.NotInUse;
                microphoneDevice.AudioSessionManager.RefreshSessions();
                for (var i = 0; i < microphoneDevice.AudioSessionManager.Sessions.Count; i++)
                {
                    var session = microphoneDevice.AudioSessionManager.Sessions[i];
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
            var shouldMute = (action == MicrophoneAction.Mute ? true : false);
            if (action == MicrophoneAction.Toggle)
            {
                var currentStatus = GetStatus();
                if (currentStatus == MicrophoneStatus.NotInUse)
                {
                    // If no mic is in use, take the mute status of the FIRST device.
                    if (this.microphoneDevices.Any())
                    {
                        shouldMute = !(this.microphoneDevices.First().AudioEndpointVolume.Mute);
                    }
                }
                else
                {
                    // If any mic is in use, take the overall mute status across all microphones.
                    shouldMute = currentStatus == MicrophoneStatus.Muted ? false : true;
                }
            }
            foreach (var microphoneDevice in this.microphoneDevices)
            {
                microphoneDevice.AudioEndpointVolume.Mute = shouldMute;
            }
            return shouldMute;
        }
    }
}