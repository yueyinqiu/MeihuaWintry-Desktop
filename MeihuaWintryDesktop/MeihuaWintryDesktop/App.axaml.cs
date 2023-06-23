using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MeihuaWintryDesktop.ViewModels;
using MeihuaWintryDesktop.Views;

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
            desktop.MainWindow = new MainWindow {
                DataContext = new MainViewModel()
            };
        }
        else if (this.ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
