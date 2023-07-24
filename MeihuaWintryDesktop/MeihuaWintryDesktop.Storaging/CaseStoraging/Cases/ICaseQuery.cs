namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface ICaseQuery
{
    ICaseQuery OrderByLastEdit(bool descending = false);
    ICaseQuery FilterByOwner(string owner);
    ICaseQuery Skip(int count);
    ICaseQuery Limit(int count);
    int Count();
    IEnumerable<IStoredCaseWithId> Query();
}
