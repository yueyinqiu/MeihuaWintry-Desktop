using System;

using Avalonia;

namespace MeihuaWintryDesktop.Desktop;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        var builder = App.BuildNonPlatform();
        _ = builder.UsePlatformDetect();
        return builder;
    }
}
