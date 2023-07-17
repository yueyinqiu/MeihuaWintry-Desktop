namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface ICaseSearchResult
{
    int PageCount(int pageSize);
    IEnumerable<IStoredCaseWithId> ToEnumerable(int pageIndex0Based, int pageSize);
}
