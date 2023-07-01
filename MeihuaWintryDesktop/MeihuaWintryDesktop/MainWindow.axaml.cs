using Avalonia.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        this.Closing += this.ThisClosing;
        this.mainView.Closed += (_, _) => this.ForceClose();
    }

    protected override void OnLoaded()
    {
        this.mainView.DataContext = this.DataContext;
    }

    bool isCloseRequired = false;
    private void ThisClosing(object? sender, WindowClosingEventArgs e)
    {
        if (this.isCloseRequired)
            return;

        e.Cancel = true;
        this.mainView.TryClose();
    }

    private void ForceClose()
    {
        this.isCloseRequired = true;
        this.Close();
    }
}
