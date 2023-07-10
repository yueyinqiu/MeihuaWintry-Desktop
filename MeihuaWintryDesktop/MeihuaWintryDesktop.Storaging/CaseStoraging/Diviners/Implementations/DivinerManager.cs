using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
public sealed class DivinerManager : IDivinerManager
{
    private readonly BsonMapper bsonMapper;
    private readonly ILiteCollection<StoredDivinerScript> scriptCollection;
    internal DivinerManager(LiteDatabase database)
    {
        this.bsonMapper = database.Mapper;
        this.scriptCollection = database.GetCollection<StoredDivinerScript>(CollectionNames.DivinerScript);
    }

    public string GetScript(DivinerScriptCategory category)
    {
        var id = this.bsonMapper.Serialize(category);
        var result = this.scriptCollection.FindById(id);
        return result?.Codes ?? "";
    }

    public void SetScript(DivinerScriptCategory category, string script)
    {
        _ = this.scriptCollection.Upsert(new StoredDivinerScript() {
            ScriptId = category,
            Codes = script
        });
    }
}
