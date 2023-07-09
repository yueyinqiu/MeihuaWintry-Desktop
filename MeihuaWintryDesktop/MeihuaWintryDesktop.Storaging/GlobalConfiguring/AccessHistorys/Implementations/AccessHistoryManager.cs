using LiteDB;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys.Implementations;
public sealed class AccessHistoryManager : IAccessHistoryManager
{
    private readonly ILiteCollection<StoredAccessHistory> collection;
    internal AccessHistoryManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<StoredAccessHistory>(CollectionNames.AccessHistorys);
    }

    public IEnumerable<IStoredAccessHistory> ListHistorys()
    {
        return this.collection.FindAll();
    }

    public void SetHistory(IStoredAccessHistory history)
    {
        var updateResult = this.collection.UpdateMany(x => new StoredAccessHistory() {
            HistoryId = x.HistoryId,
            File = x.File,
            IsTrusted = history.IsTrusted,
            LastAccess = history.LastAccess
        }, x => x.File == history.File.FullName);
        if (updateResult is 0)
        {
            this.collection.Insert(StoredAccessHistory.FromInterfaceType(history));
        }
    }

    public IStoredAccessHistory? TryGetHistory(FileInfo store)
    {
        return this.collection.FindOne(x => x.File == store.FullName);
    }
}
