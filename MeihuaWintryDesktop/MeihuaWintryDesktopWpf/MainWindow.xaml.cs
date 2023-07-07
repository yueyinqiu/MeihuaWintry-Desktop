using System.ComponentModel;
using System.Windows;

namespace MeihuaWintryDesktopWpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.Closing += this.ThisClosing;
        this.mainView.Closed += (_, _) => this.InvokeClose();
    }

    bool isCloseRequired = false;
    private void ThisClosing(object sender, CancelEventArgs e)
    {
        if (this.isCloseRequired)
            return;

        e.Cancel = true;
        this.mainView.TryClose();
    }

    private void InvokeClose()
    {
        this.isCloseRequired = true;
        _ = this.Dispatcher.InvokeAsync(this.Close);
    }
}
