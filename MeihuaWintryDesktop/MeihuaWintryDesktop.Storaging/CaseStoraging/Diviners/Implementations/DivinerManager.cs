using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
internal sealed class DivinerManager : IDivinerManager
{
    private readonly ILiteCollection<StoredDiviner> scriptCollection;
    internal DivinerManager(LiteDatabase database)
    {
        this.scriptCollection = database.GetCollection<StoredDiviner>(CollectionNames.Diviners);
    }

    public IStoredDiviner Diviner
    {
        get
        {
            var result = this.scriptCollection.FindById(StoredDiviner.PossibleId);
            return result ?? new StoredDiviner() {
                PreScript = "",
                DefaultScript = "",
                PostScript = "",
            };
        }
        set
        {
            var d = StoredDiviner.FromInterfaceType(value);
            this.scriptCollection.Upsert(d);
        }
    }
}
