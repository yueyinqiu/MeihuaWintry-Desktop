using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;
public interface ISettingsManager
{
    public string GetStoreNotes();
    public void SetStoreNotes(string s);
}
