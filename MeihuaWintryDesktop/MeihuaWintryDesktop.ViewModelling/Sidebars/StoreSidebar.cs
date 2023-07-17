using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using System.Collections.ObjectModel;
using System.Linq;
using static MeihuaWintryDesktop.ViewModelling.Sidebars.SearchedCase;

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
        this.ListingCases = Array.Empty<SearchedCase>();

        this.searchedCases = (store.Cases.ListCasesByLastEdit(), _ => "");
        this.CurrentPageIndex = 1;
    }

    private (ICaseSearchResult Cases, SearchingDetailProvider Details) searchedCases;

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
        if(resetPageIndex && this.CurrentPageIndex is not 1)
        {
            this.CurrentPageIndex = 1;
            // 在该属性被被改变后，此方法会自动被调用，因此这边直接返回。
            return;
        }

        const int pageSize = 20;
        var searchedCases = this.searchedCases;
        this.TotalPageCount = searchedCases.Cases.PageCount(pageSize);
        this.ListingCases = searchedCases.Cases
            .ToEnumerable(this.CurrentPageIndex - 1, pageSize)
            .Select(x => new SearchedCase(x, searchedCases.Details));
    }
}
