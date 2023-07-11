using MeihuaWintryDesktop.ViewModelling;
using MeihuaWintryDesktop.ViewModelling.Tools.ParameterizedStarting;
using System.Linq;
using System.Windows;

namespace MeihuaWintryDesktopWpf;

public partial class App : Application
{
    private ProgramEntry programEntry;

    private void ThisStartup(object sender, StartupEventArgs e)
    {
        var args = new StartingArguments(e.Args.FirstOrDefault());
        this.programEntry = new ProgramEntry(args);

        this.MainWindow = new MainWindow() {
            DataContext = this.programEntry.MainViewModel
        };
        this.MainWindow.Show();
    }

    private void ThisExit(object sender, ExitEventArgs e)
    {
        this.programEntry?.Dispose();
    }
}