![MicMuter Logo](MicMuter-Logo.png)

**MicMuter** is a small Windows utility that allows you to very simply toggle your microphone on or off, either with a keyboard shortcut (`Windows + Shift + A` by default) or by clicking on its icon in the notification area. That icon also shows the current status of your microphone so you can always see at a glance whether it's unmuted, muted or not in use.

The application is intentionally kept minimal and runs as a single portable executable: no installer required, simply grab the latest version from the [releases](./releases/latest) page and run! You can also configure it to run at startup so you won't have to worry about it again.

You do need [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) to run but this comes preinstalled with Windows 10 April 2018 Update or newer - so it's highly likely you already have this.

### Alternatives

Here are a few alternative solutions you may want to consider:

- [Microsoft PowerToys](https://docs.microsoft.com/windows/powertoys/)
  - The PowerToys include a [Video Conference Mute](https://docs.microsoft.com/windows/powertoys/video-conference-mute) utility which not only mutes the microphone but also the camera.
  - This adds a virtual driver for your camera and a lot of other utilities though, so it may be overkill if all you need is a way to mute your mic.
- [MicSwitch](https://github.com/iXab3r/MicSwitch)
  - This is a more fully-featured application which can also show an overlay and play sounds.
  - It's not a portable application though so it needs to be installed, and it's configured to run with administrator privileges which you may not like.

### License

MicMuter is freeware, enjoy! Shout out to [NAudio](https://github.com/naudio/NAudio) for providing the great audio library being used here.
