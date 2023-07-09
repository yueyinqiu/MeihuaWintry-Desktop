namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;
public interface IAccessHistoryManager
{
    void SetHistory(IStoredAccessHistory history);
    IStoredAccessHistory? TryGetHistory(FileInfo store);
    IEnumerable<IStoredAccessHistory> ListHistorys();
}
