using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;

namespace MeihuaWintryDesktop.StoragingTests.CaseStoraging.Entities;
internal class StoredDiviner : IStoredDiviner
{
    public string PreScript { get; set; }

    public string DefaultScript { get; set; }

    public string PostScript { get; set; }
}
