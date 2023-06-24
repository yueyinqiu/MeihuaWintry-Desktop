using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.ViewModels.CaseStoraging;
using MeihuaWintryDesktop.ViewModels.Entities;
using System;
using System.Diagnostics;
using System.IO;

namespace MeihuaWintryDesktop.ViewModels;

public sealed partial class CaseStorageDisplayPageViewModel : ObservableObject, IPageViewModel, IDisposable
{
    private readonly INavigationManager navigation;
    public CaseStorageDisplayPageViewModel(INavigationManager navigation)
    {
        this.navigation = navigation;
    }

    [ObservableProperty]
    private CaseStorageFile? caseStorageFile;

    public void CloseStorage()
    {
        this.CaseStorageFile?.Dispose();
    }

    public void LoadStorage(string path)
    {
        CloseStorage();

        if (!File.Exists(path))
        {
            CaseStorageFile = null;
            return;
        }

        CaseStorageFile = new CaseStorageFile(new FileInfo(path));
    }

    public void Dispose()
    {
        CloseStorage();
    }
}
