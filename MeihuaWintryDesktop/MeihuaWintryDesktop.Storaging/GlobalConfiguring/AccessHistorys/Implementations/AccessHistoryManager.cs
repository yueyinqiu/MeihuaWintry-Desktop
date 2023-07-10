using LiteDB;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys.Implementations;
public sealed class AccessHistoryManager : IAccessHistoryManager
{
    private readonly ILiteCollection<StoredAccessHistory> collection;
    internal AccessHistoryManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<StoredAccessHistory>(CollectionNames.AccessHistorys);

        this.collection.EnsureIndex(x => x.LastAccess);
    }

    public IEnumerable<IStoredAccessHistory> ListHistorysByLastAccess()
    {
        return this.collection.Query()
            .OrderByDescending(x => x.LastAccess)
            .ToEnumerable();
    }

    public void SetHistory(IStoredAccessHistory history)
    {
        _ = this.collection.Upsert(StoredAccessHistory.FromInterfaceType(history));
    }

    public IStoredAccessHistory? TryGetHistory(FileInfo store)
    {
        return this.collection.FindById(store.FullName);
    }
}
