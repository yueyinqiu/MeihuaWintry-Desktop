using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public string SearchingDetails => searchingDetails(this.InnerCase);
}
