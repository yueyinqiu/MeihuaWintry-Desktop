using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class CaseSearchResult : ICaseSearchResult
{
    private readonly ILiteQueryable<StoredCase> query;
    internal CaseSearchResult(ILiteQueryable<StoredCase> query)
    {
        this.query = query;
    }

    public int PageCount(int pageSize)
    {
        return (query.Count() + pageSize - 1) / pageSize;
    }

    public IEnumerable<IStoredCaseWithId> ToEnumerable(int pageIndex0Based, int pageSize)
    {
        return query.Skip(pageIndex0Based * pageSize).Limit(pageSize).ToEnumerable();
    }
}
