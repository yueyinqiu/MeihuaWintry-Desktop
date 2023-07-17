using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public sealed partial class StoreSidebar : SidebarBase, ISidebarViewModel
{
    private readonly CaseStore store;

    protected override CaseStore? GetStoreIfExists()
    {
        return this.store;
    }

    internal StoreSidebar(MainViewModel mainViewModel, DisposableManager disposableManager, CaseStore store) 
        : base(mainViewModel, disposableManager)
    {
        this.store = store;
    }
}
