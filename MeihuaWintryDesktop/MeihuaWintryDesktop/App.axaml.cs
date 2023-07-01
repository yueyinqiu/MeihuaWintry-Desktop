using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MeihuaWintryDesktop.ViewModelling;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MeihuaWintryDesktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private static DirectoryInfo GetDataDirectory()
    {
        var currentPath = Environment.CurrentDirectory;
        var hashedCurrent = SHA256.HashData(Encoding.UTF8.GetBytes(currentPath));

        var identifier = Convert.ToHexString(hashedCurrent)[..16];

        var folderType = Environment.SpecialFolder.LocalApplicationData;
        var resultPath = Environment.GetFolderPath(folderType);
        resultPath = Path.GetFullPath("MeihuaWintryDesktop", resultPath);
        resultPath = Path.GetFullPath(identifier, resultPath);

        return new DirectoryInfo(resultPath);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);

        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLiftTime)
        {
            desktopLiftTime.MainWindow = new MainWindow() {
                DataContext = new MainViewModel()
            };
        }
        else if (this.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
        {
            singleView.MainView = new MainView() {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
