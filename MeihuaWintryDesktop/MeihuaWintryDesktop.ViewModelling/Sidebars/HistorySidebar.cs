using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public sealed partial class HistorySidebar : SidebarBase, ISidebarViewModel
{
    protected override CaseStore? GetStoreIfExists()
    {
        return null;
    }

    internal HistorySidebar(MainViewModel mainViewModel, GlobalConfiguration configurations) : base(mainViewModel)
    {
        this.Histories =
            configurations.AccessHistorys.ListHistorysByLastAccess()
            .Select(x => new AccessHistory(x))
            .ToArray();
    }

    public IReadOnlyCollection<AccessHistory> Histories { get; }
}
