using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings.Implementations;
public sealed class SettingsManager : ISettingsManager
{
    private readonly ILiteCollection<Settings> collection;
    internal SettingsManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<Settings>(CollectionNames.Settings);
    }

    private Settings GetSettings()
    {
        var result = this.collection.FindById(Settings.PossibleId);
        return result ?? new Settings() {
            Notes = ""
        };
    }

    private void SaveSettings(Settings settings)
    {
        Debug.Assert(settings.Id == Settings.PossibleId);
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
