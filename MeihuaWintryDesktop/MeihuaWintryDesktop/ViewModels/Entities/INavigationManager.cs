namespace MeihuaWintryDesktop.ViewModels.Entities;
public interface INavigationManager
{
    void NavigateTo<T>(T viewModel, bool disposeCurrent = true) where T : IPageViewModel;
}
