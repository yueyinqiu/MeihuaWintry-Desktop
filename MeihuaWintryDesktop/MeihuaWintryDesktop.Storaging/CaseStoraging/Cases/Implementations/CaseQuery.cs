using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class CaseQuery : ICaseQuery
{
    private readonly ILiteQueryable<StoredCase> query;
    internal CaseQuery(ILiteCollection<StoredCase> collection)
    {
        this.query = collection.Query();
    }

    public int Count()
    {
        return query.Count();
    }

    public ICaseQuery FilterByOwner(string owner)
    {
        _ = this.query.Where(x => x.Owner == owner);
        return this;
    }

    public ICaseQuery Limit(int count)
    {
        _ = this.query.Limit(count);
        return this;
    }

    public ICaseQuery OrderByLastEdit(bool descending = false)
    {
        if (descending)
            _ = this.query.OrderByDescending(x => x.LastEdit);
        else
            _ = this.query.OrderBy(x => x.LastEdit);
        return this;
    }

    public IEnumerable<IStoredCaseWithId> Query()
    {
        return this.query.ToEnumerable();
    }

    public ICaseQuery Skip(int count)
    {
        _ = this.query.Skip(count);
        return this;
    }
}
