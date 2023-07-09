using LiteDB;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys.Implementations;
internal sealed class StoredAccessHistory : IStoredAccessHistory
{
    [BsonId]
    public required ObjectId? HistoryId { get; set; }

    public required string? File { get; set; }
    FileInfo IStoredAccessHistory.File => new FileInfo(this.File!);

    public required DateTime LastAccess { get; set; }
    public required bool IsTrusted { get; set; }

    public static StoredAccessHistory FromInterfaceType(IStoredAccessHistory h)
    {
        return new StoredAccessHistory() {
            File = h.File.FullName,
            HistoryId = null,
            IsTrusted = h.IsTrusted,
            LastAccess = h.LastAccess
        };
    }
}
