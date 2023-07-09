namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;
public interface IStoredAccessHistory
{
    FileInfo File { get; }
    DateTime LastAccess { get; }
    bool IsTrusted { get; }
}
