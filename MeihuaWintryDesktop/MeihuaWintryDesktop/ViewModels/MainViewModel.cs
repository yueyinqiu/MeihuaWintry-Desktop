using CommunityToolkit.Mvvm.ComponentModel;

namespace MeihuaWintryDesktop.ViewModels;

public sealed partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject currentView = new TestViewModel();
}
