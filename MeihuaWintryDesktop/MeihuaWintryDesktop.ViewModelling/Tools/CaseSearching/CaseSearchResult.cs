using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching.CaseSearchResult;

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
        return (factory().Count() + this.PageSize - 1) / this.PageSize;
    }
    public IEnumerable<SearchedCase> GetPage(int index0Based)
    {
        return factory()
            .Skip(index0Based * this.PageSize)
            .Limit(this.PageSize)
            .Query()
            .Select(x => new SearchedCase(x, detailSelector?.Invoke(x)));
    }
}
