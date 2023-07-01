using Avalonia.Controls;
using MeihuaWintryDesktop.Extensions;
using MeihuaWintryDesktop.ViewModelling;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop;

public partial class MainView : UserControl
{
    public MainView()
    {
        this.InitializeComponent();
    }

    private MainViewModel ViewModel => this.DataContext.As<MainViewModel>();

    protected override void OnLoaded()
    {
        this.ViewModel.PropertyChanged += (sender, e) => {
            var viewModel = sender.As<MainViewModel>();
            if (e.PropertyName is not nameof(viewModel.IsClosed))
                return;
            if (viewModel.IsClosed)
                this.Closed?.Invoke(this, EventArgs.Empty);
        };
    }

    public event EventHandler? Closed;

    public void TryClose()
    {
        if (this.ViewModel.RequestCloseCommand.CanExecute(null) is true)
            this.ViewModel.RequestCloseCommand.Execute(null);
    }
}
