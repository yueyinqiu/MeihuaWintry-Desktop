using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.StoragingTests.CaseStoraging.Entities;
internal class Case : IStoredCaseWithId
{
    public string Title { get; set; }

    public string Owner { get; set; }

    public string OwnerDescription { get; set; }

    public IStoredGregorianTime GregorianTime { get; set; }

    public IStoredChineseSolarTime ChineseSolarTime { get; set; }

    public IStoredChineseLunarTime ChineseLunarTime { get; set; }

    public IEnumerable<IStoredNumber> Numbers { get; set; }

    public IEnumerable<IStoredGua> Guas { get; set; }

    public string Notes { get; set; }

    public IEnumerable<string> Tags { get; set; }

    public ObjectId CaseId { get; set; }
}
