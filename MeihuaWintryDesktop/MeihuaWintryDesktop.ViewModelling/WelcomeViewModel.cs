using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class WelcomeViewModel : ObservableObject, IEditorViewModel
{
    [ObservableProperty]
    private bool isNotSaved;

    [ObservableProperty]
    private string title = "Welcome";
}
