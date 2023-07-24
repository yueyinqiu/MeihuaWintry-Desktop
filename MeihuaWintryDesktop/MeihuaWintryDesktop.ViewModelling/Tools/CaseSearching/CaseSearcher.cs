using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching;
internal sealed class CaseSearcher
{
    private readonly CaseStore store;
    public CaseSearcher(CaseStore store)
    {
        this.store = store;
    }

    public CaseSearchResult Search(
        OrderByOptions orderby, bool descending)
    {
        ICaseQuery QueryFactory()
        {
            var result = store.Cases.CreateQuery();
            _ = orderby switch {
                OrderByOptions.LastEdit => result.OrderByLastEdit(descending),
                _ => result
            };
            return result;
        }
        return new(QueryFactory, null);
    }
}
