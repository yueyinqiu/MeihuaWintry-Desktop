using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.ViewModels.Entities;

namespace MeihuaWintryDesktop.ViewModels;

public sealed partial class WelcomePageViewModel : ObservableObject, IPageViewModel
{
    private readonly INavigationManager navigation;
    public WelcomePageViewModel(INavigationManager navigation)
    {
        this.navigation = navigation;
    }

    public string WelcomeText => "欢迎使用冬日梅花";

    private void OpenFile()
    {
        
    }

    public void Dispose()
    {
    }
}
