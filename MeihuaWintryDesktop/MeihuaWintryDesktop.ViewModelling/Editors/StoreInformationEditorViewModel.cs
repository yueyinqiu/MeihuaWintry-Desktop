using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class StoreInformationEditorViewModel : ObservableObject, IEditorViewModel, IRequiresSaving
{
    private readonly CaseStore caseStore;

    public StoreInformationEditorViewModel(CaseStore caseStore)
    {
        this.caseStore = caseStore;
        this.Notes = caseStore.Settings.GetStoreNotes();
    }

    public string FileName => caseStore.File.Name;

    [ObservableProperty]
    private string notes;

    public void Save()
    {
        this.caseStore.Settings.SetStoreNotes(this.Notes);
    }
}
