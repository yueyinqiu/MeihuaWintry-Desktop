using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;

internal sealed class StoredCase : IStoredCaseWithId
{
    private static IEnumerable<T> SelectNotNull<T>(IEnumerable<T?>? values)
    {
        if (values is null)
            yield break;
        foreach (var value in values)
        {
            if (value is not null)
                yield return value;
        }
    }

    public ObjectId? CaseId { get; set; }
    ObjectId IStoredCaseWithId.CaseId => this.CaseId ?? ObjectId.Empty;

    public DateTime LastEdit { get; set; }

    public string? Title { get; set; }
    string IStoredCase.Title => this.Title ?? "";

    public string? Owner { get; set; }
    string IStoredCase.Owner => this.Owner ?? "";
    public string? OwnerDescription { get; set; }
    string IStoredCase.OwnerDescription => this.OwnerDescription ?? "";

    // public GregorianTime? GregorianTime { get; set; }
    IGregorianTime IStoredCase.GregorianTime => throw new NotImplementedException();
    public ChineseSolarTime? ChineseSolarTime { get; set; }
    IChineseSolarTime IStoredCase.ChineseSolarTime => this.ChineseSolarTime ?? new ChineseSolarTime();
    // public ChineseLunarTime? ChineseLunarTime { get; set; }
    IChineseLunarTime IStoredCase.ChineseLunarTime => throw new NotImplementedException();

    public NamedStruct<int>?[]? Numbers { get; set; }
    IEnumerable<INamed<int>> IStoredCase.Numbers => SelectNotNull(this.Numbers);
    public NamedGua?[]? Guas { get; set; }
    IEnumerable<INamed<Gua>> IStoredCase.Guas => SelectNotNull(this.Guas);

    public string? Notes { get; set; }
    string IStoredCase.Notes => this.Notes ?? "";
    public string?[]? Tags { get; set; }
    IEnumerable<string> IStoredCase.Tags => SelectNotNull(this.Tags);
}
