using MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;

namespace MeihuaWintryDesktop.StoragingTests.GlobalConfiguring.Entities;
internal class AccessHistory : IStoredAccessHistory
{
    public FileInfo File { get; set; }
    public DateTime LastAccess { get; set; }
    public bool IsTrusted { get; set; }
}
