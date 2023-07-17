using LiteDB;

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
        return (this.query.Count() + pageSize - 1) / pageSize;
    }

    public IEnumerable<IStoredCaseWithId> ToEnumerable(int pageIndex0Based, int pageSize)
    {
        return this.query.Skip(pageIndex0Based * pageSize).Limit(pageSize).ToEnumerable();
    }
}
