using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching.Options;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars.Store;

public sealed partial class StoreSidebar : SidebarBase, ISidebarViewModel
{
    private readonly CaseStore store;
    private readonly CaseSearcher caseSearcher;
    protected override CaseStore? GetStoreIfExists()
    {
        return this.store;
    }

    internal StoreSidebar(IMainContext context, DisposableManager disposableManager, CaseStore store)
        : base(context, disposableManager)
    {
        this.store = store;
        this.caseSearcher = new CaseSearcher(store);

        this.ListingCases = Array.Empty<SearchedCase>();

        this.searchedCases = this.caseSearcher.Search(OrderByOptions.LastEdit, true);
        this.CurrentPageIndex = 1;
    }

    private CaseSearchResult searchedCases;

    [ObservableProperty]
    private IEnumerable<SearchedCase> listingCases;

    [ObservableProperty]
    private int currentPageIndex;

    [ObservableProperty]
    private int totalPageCount;

    partial void OnCurrentPageIndexChanged(int value)
    {
        this.RefreshPageStates(false);
    }

    private void RefreshPageStates(bool resetPageIndex)
    {
        if (resetPageIndex && this.CurrentPageIndex is not 1)
        {
            this.CurrentPageIndex = 1;
            // 在该属性被被改变后，此方法会自动被调用，因此这边直接返回。
            return;
        }

        var searchedCases = this.searchedCases;
        this.TotalPageCount = searchedCases.GetPageCount();
        this.ListingCases = searchedCases.GetPage(this.CurrentPageIndex - 1);
    }
}
