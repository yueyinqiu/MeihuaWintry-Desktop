using MeihuaWintryDesktop.ViewModelling;
using System.Windows;

namespace MeihuaWintryDesktopWpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        this.MainWindow = new MainWindow() {
            DataContext = new MainViewModel()
        };
        this.MainWindow.Show();
    }
}