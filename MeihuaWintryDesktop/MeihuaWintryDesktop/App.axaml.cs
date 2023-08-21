using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MeihuaWintryDesktop.ViewModelling;
using System.Linq;

namespace MeihuaWintryDesktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);
        
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var entry = new ProgramEntry(new(desktop.Args?.FirstOrDefault()));
            desktop.MainWindow = new MainWindow(entry);
        }
        else if (this.ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var entry = new ProgramEntry(new(null));
            singleViewPlatform.MainView = new MainView(entry);
        }

        base.OnFrameworkInitializationCompleted();
    }
}
