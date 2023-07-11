using MeihuaWintryDesktop.ViewModelling;
using System.Windows;

namespace MeihuaWintryDesktopWpf;

public partial class App : Application
{
    private MainViewModel mainViewModel;

    private void ThisStartup(object sender, StartupEventArgs e)
    {
        this.mainViewModel = new MainViewModel();

        this.MainWindow = new MainWindow() {
            DataContext = this.mainViewModel
        };
        this.MainWindow.Show();
    }

    private void ThisExit(object sender, ExitEventArgs e)
    {
        this.mainViewModel?.Dispose();
    }
}