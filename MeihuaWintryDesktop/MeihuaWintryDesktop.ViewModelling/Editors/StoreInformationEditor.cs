using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class StoreInformationEditor : ObservableObject, IEditorViewModel
{
    private readonly CaseStore store;

    internal StoreInformationEditor(CaseStore store)
    {
        this.store = store;
        this.Notes = store.Settings.StoreNotes;
    }

    public string FileName => this.store.File.Name;

    [ObservableProperty]
    private string notes;

    partial void OnNotesChanging(string value)
    {
        this.store.Settings.StoreNotes = this.Notes;
    }
}
