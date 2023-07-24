using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching;
internal sealed class CaseSearchResult
{
    public delegate ICaseQuery QueryFactory();
    public delegate string SearchDetailSelector(IStoredCaseWithId storedCase);

    private readonly QueryFactory factory;
    private readonly SearchDetailSelector? detailSelector;
    public CaseSearchResult(QueryFactory factoryUnpaged, SearchDetailSelector? detailSelector)
    {
        this.factory = factoryUnpaged;
        this.detailSelector = detailSelector;
    }

    public int PageSize { get; set; } = 20;

    public int GetPageCount()
    {
        return (this.factory().Count() + this.PageSize - 1) / this.PageSize;
    }
    public IEnumerable<SearchedCase> GetPage(int index0Based)
    {
        return this.factory()
            .Skip(index0Based * this.PageSize)
            .Limit(this.PageSize)
            .Query()
            .Select(x => new SearchedCase(x, this.detailSelector?.Invoke(x)));
    }
}
