using LiteDB;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings.Implementations;
public sealed class SettingsManager : ISettingsManager
{
    private readonly ILiteCollection<StoredSettings> collection;
    internal SettingsManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<StoredSettings>(CollectionNames.Settings);
    }

    private StoredSettings GetSettings()
    {
        var result = this.collection.FindById(StoredSettings.PossibleId);
        return result ?? new StoredSettings() {
            Notes = ""
        };
    }

    private void SaveSettings(StoredSettings settings)
    {
        Debug.Assert(settings.Id == StoredSettings.PossibleId);
        this.collection.Upsert(settings);
    }

    public string StoreNotes
    {
        get
        {
            return this.GetSettings().Notes ?? "";
        }
        set
        {
            var settings = this.GetSettings();
            settings.Notes = value;
            this.SaveSettings(settings);
        }
    }
}
