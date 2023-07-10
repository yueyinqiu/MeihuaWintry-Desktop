using LiteDB;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
public sealed class DivinerManager : IDivinerManager
{
    private readonly ILiteCollection<StoredDivinerScript> scriptCollection;
    internal DivinerManager(LiteDatabase database)
    {
        this.scriptCollection = database.GetCollection<StoredDivinerScript>(CollectionNames.DivinerScript);
    }

    public string GetScript(DivinerScriptCategory category)
    {
        Debug.Assert((int)category > 0);
        var result = this.scriptCollection.FindById((int)category);
        return result?.Codes ?? "";
    }

    public void SetScript(DivinerScriptCategory category, string script)
    {
        Debug.Assert((int)category > 0);
        _ = this.scriptCollection.Upsert(new StoredDivinerScript() {
            ScriptId = (int)category,
            Codes = script
        });
    }
}
