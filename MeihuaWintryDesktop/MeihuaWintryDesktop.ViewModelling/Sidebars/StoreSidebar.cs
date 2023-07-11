using MeihuaWintryDesktop.Storaging.CaseStoraging;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public sealed partial class StoreSidebar : SidebarBase, ISidebarViewModel
{
    private readonly CaseStore store;

    protected override CaseStore? GetStoreIfExists()
    {
        return this.store;
    }

    internal StoreSidebar(MainViewModel mainViewModel, CaseStore store) : base(mainViewModel)
    {
        this.store = store;
    }
}
