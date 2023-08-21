using Avalonia.Controls;
using MeihuaWintryDesktop.ViewModelling;

namespace MeihuaWintryDesktop;

public partial class MainView : UserControl
{
    public MainView(ProgramEntry entry)
    {
        this.InitializeComponent();

        entry.MainViewModel.PropertyChanged += (obj, e) => {
            if (e.PropertyName is nameof(MainViewModel.IsClosed))
            {
                if(((MainViewModel)obj).IsClosed)
                {
                    this[];
                }
            }
        };
    }

    private void MainViewModelClosed()
    {
        throw new System.NotImplementedException();
    }
}
