using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using MeihuaWintryDesktop.ViewModels;
using MeihuaWintryDesktop.Views;
using System;

namespace MeihuaWintryDesktop;

public sealed partial class App : Application
{
    public static AppBuilder BuildNonPlatform()
    {
        var builder = AppBuilder.Configure<App>();
        _ = builder.WithInterFont();
        _ = builder.LogToTrace();
        return builder;
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new MainWindow();
            window.DataContext = new MainViewModel(window.StorageProvider, desktop.Args);
            desktop.MainWindow = window;
        }
        else if (this.ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView() {
                // TODO: add support for those platforms
                DataContext = new MainViewModel(null)
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}
