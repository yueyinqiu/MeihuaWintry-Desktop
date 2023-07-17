using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;
public sealed class SearchedCase
{
    public delegate string SearchingDetailProvider(IStoredCaseWithId storedCase);


    private readonly SearchingDetailProvider searchingDetails;
    internal IStoredCaseWithId InnerCase { get; }
    internal SearchedCase(IStoredCaseWithId storedCase, SearchingDetailProvider searchingDetails)
    {
        this.InnerCase = storedCase;
        this.searchingDetails = searchingDetails;
    }
    public string Title => this.InnerCase.Title;
    public string SearchingDetails => this.searchingDetails(this.InnerCase);
}
