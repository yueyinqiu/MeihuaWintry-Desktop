using MeihuaWintryDesktop.ViewModelling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeihuaWintryDesktopWpf;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.Closing += this.ThisClosing;
        this.mainView.Closed += (_, _) => this.InvokeClose();
    }

    bool isCloseRequired = false;
    private void ThisClosing(object? sender, CancelEventArgs e)
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
