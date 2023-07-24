using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class CaseCreationEditor : ObservableObject, IEditorViewModel
{
    private readonly CaseStore store;

    internal CaseCreationEditor(CaseStore store)
    {
        this.store = store;
    }

    [ObservableProperty]
    private string title = "";

    [ObservableProperty]
    private string owner = "";

    [ObservableProperty]
    private string script = "";
}
