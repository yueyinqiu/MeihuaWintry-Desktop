using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

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
            return GetSettings().Notes ?? "";
        }
        set
        {
            var settings = GetSettings();
            settings.Notes = value;
            SaveSettings(settings);
        }
    }
}
