using MeihuaWintryDesktop.ViewModelling;
using MeihuaWintryDesktop.Extensions;
using System;
using System.Windows.Controls;

namespace MeihuaWintryDesktop;

public partial class MainView : UserControl
{
    public MainView()
    {
        this.InitializeComponent();

        this.DataContextChanged += (_, _) => {
            this.ViewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName is not nameof(MainViewModel.IsClosed))
                    return;
                if (sender.As<MainViewModel>().IsClosed)
                    this.Closed?.Invoke(this, EventArgs.Empty);
            };
        };
    }

    public event EventHandler Closed;

    private MainViewModel ViewModel => this.DataContext.As<MainViewModel>();

    public void TryClose()
    {
        if (this.ViewModel.RequestCloseCommand.CanExecute(null) is true)
            this.ViewModel.RequestCloseCommand.Execute(null);
    }
}
