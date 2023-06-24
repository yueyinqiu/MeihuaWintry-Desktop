using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModels;

public sealed partial class MainViewModel : ObservableObject, INavigationManager
{
    [ObservableProperty]
    private IPageViewModel currentPage;

    private readonly IStorageProvider? storageProvider;

    public MainViewModel(IStorageProvider? defaultStorageProvider, string[]? args = null)
    {
        storageProvider = defaultStorageProvider;

        if (defaultStorageProvider is null ||
            !defaultStorageProvider.CanOpen ||
            !defaultStorageProvider.CanSave)
        {
            // TODO: 或许可以在这里写一个自己的实现并使用？
            this.CurrentPage = new ErrorPageViewModel(
                "没有在此平台上找到可用的文件选择器，因此冬日梅花可能无法正常运行。" +
                "您可以将此问题告知我们，我们会尽力在更多平台上提供支持。");
        }

        if (args?.Length >= 1)
        {
            var page = new CaseStorageDisplayPageViewModel(this);
            page.LoadStorage(args[0]);
            this.CurrentPage = page;
        }
        else
        {
            this.CurrentPage = new WelcomePageViewModel(this);
        }
    }

    public void NavigateTo<T>(T viewModel, bool disposeCurrent) where T : IPageViewModel
    {
        if (disposeCurrent)
            this.CurrentPage.Dispose();
        this.CurrentPage = viewModel;
    }

    [RelayCommand]
    private async Task Test()
    {
        await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions() {
            FileTypeFilter = new List<FilePickerFileType>() {
             }
        });
    }
}
