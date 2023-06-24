using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.ViewModels.Entities;

namespace MeihuaWintryDesktop.ViewModels;

public sealed partial class ErrorPageViewModel : IPageViewModel
{
    public ErrorPageViewModel(string message)
    {
        this.Message = message;
    }

    public string Message { get; }

    public void Dispose()
    {
    }
}
