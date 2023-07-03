using MeihuaWintryDesktop.ViewModelling;
using MeihuaWintryDesktopWpf.Extensions;
using System;
using System.Collections.Generic;
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
/// MainView.xaml 的交互逻辑
/// </summary>
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        this.DataContextChanged += (_, _) => {
            this.ViewModel.PropertyChanged += (sender, e) => {
                var viewModel = sender.As<MainViewModel>();
                if (e.PropertyName is not nameof(viewModel.IsClosed))
                    return;
                if (viewModel.IsClosed)
                    this.Closed?.Invoke(this, EventArgs.Empty);
            };
        };
    }

    public event EventHandler? Closed;

    private MainViewModel ViewModel => this.DataContext.As<MainViewModel>();

    public void TryClose()
    {
        if (this.ViewModel.RequestCloseCommand.CanExecute(null) is true)
            this.ViewModel.RequestCloseCommand.Execute(null);
    }
}
