using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars.History;

public sealed partial class HistorySidebar : SidebarBase, ISidebarViewModel
{
    protected override CaseStore? GetStoreIfExists()
    {
        return null;
    }

    internal HistorySidebar(IMainContext mainContext, DisposableManager disposableManager, GlobalConfiguration configurations)
        : base(mainContext, disposableManager)
    {
        this.Histories =
            configurations.AccessHistorys.ListHistorysByLastAccess()
            .Select(x => new AccessHistory(x))
            .ToArray();
    }

    public IReadOnlyCollection<AccessHistory> Histories { get; }
}
