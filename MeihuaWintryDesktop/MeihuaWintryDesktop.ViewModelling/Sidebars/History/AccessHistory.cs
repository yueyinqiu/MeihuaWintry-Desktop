using MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars.History;
public sealed class AccessHistory : IStoredAccessHistory
{
    internal AccessHistory(IStoredAccessHistory history)
    {
        this.File = history.File;
        this.LastAccess = history.LastAccess;
        this.IsTrusted = history.IsTrusted;
    }

    public FileInfo File { get; internal set; }
    public DateTime LastAccess { get; internal set; }
    public bool IsTrusted { get; internal set; }
}
