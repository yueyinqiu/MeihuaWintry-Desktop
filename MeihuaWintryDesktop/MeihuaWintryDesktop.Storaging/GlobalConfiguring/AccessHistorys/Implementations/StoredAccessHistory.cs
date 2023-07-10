using LiteDB;
using System.Diagnostics.CodeAnalysis;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys.Implementations;
internal sealed class StoredAccessHistory : IStoredAccessHistory
{
    private FileInfo file;
    [BsonId]
    public required FileInfo File
    {
        get => this.file;
        [MemberNotNull(nameof(file))]
        set
        {
            // new FileInfo("") 一般会抛出 System.ArgumentException ，
            // 此处故意用这种写法表示我们认为 null 就是 "" ，然后和其他 FileInfo 一样转换。
            this.file = value ?? new FileInfo("");
        }
    }

    public required DateTime LastAccess { get; set; }
    public required bool IsTrusted { get; set; }

    public static StoredAccessHistory FromInterfaceType(IStoredAccessHistory h)
    {
        return new StoredAccessHistory() {
            File = h.File,
            IsTrusted = h.IsTrusted,
            LastAccess = h.LastAccess
        };
    }
}
