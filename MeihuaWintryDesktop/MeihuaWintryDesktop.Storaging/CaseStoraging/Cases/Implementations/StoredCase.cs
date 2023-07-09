using LiteDB;

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

    [BsonId]
    public required ObjectId? CaseId { get; set; }
    ObjectId IStoredCaseWithId.CaseId => this.CaseId ?? ObjectId.Empty;

    public required DateTime LastEdit { get; set; }

    public required string? Title { get; set; }
    string IStoredCase.Title => this.Title ?? "";

    public required string? Owner { get; set; }
    string IStoredCase.Owner => this.Owner ?? "";
    public required string? OwnerDescription { get; set; }
    string IStoredCase.OwnerDescription => this.OwnerDescription ?? "";

    public required StoredGregorianTime? GregorianTime { get; set; }
    IStoredGregorianTime IStoredCase.GregorianTime => this.GregorianTime ?? StoredGregorianTime.Empty;
    public required StoredChineseSolarTime? ChineseSolarTime { get; set; }
    IStoredChineseSolarTime IStoredCase.ChineseSolarTime => this.ChineseSolarTime ?? StoredChineseSolarTime.Empty;
    public required StoredChineseLunarTime? ChineseLunarTime { get; set; }
    IStoredChineseLunarTime IStoredCase.ChineseLunarTime => this.ChineseLunarTime ?? StoredChineseLunarTime.Empty;

    public required StoredNumber?[]? Numbers { get; set; }
    IEnumerable<IStoredNumber> IStoredCase.Numbers => SelectNotNull(this.Numbers);
    public required StoredGua?[]? Guas { get; set; }
    IEnumerable<IStoredGua> IStoredCase.Guas => SelectNotNull(this.Guas);

    public required string? Notes { get; set; }
    string IStoredCase.Notes => this.Notes ?? "";
    public required string?[]? Tags { get; set; }
    IEnumerable<string> IStoredCase.Tags => SelectNotNull(this.Tags);

    public static StoredCase FromInterfaceTypeNoId(
        IStoredCase c, DateTime? lastEdit = null)
    {
        return new StoredCase() {
            CaseId = null,
            ChineseLunarTime = StoredChineseLunarTime.FromInterfaceType(c.ChineseLunarTime),
            ChineseSolarTime = StoredChineseSolarTime.FromInterfaceType(c.ChineseSolarTime),
            GregorianTime = StoredGregorianTime.FromInterfaceType(c.GregorianTime),
            Guas = c.Guas.Select(StoredGua.FromInterfaceType).ToArray(),
            LastEdit = lastEdit ?? DateTime.Now,
            Notes = c.Notes,
            Numbers = c.Numbers.Select(StoredNumber.FromInterfaceType).ToArray(),
            Owner = c.Owner,
            OwnerDescription = c.OwnerDescription,
            Tags = c.Tags.ToArray(),
            Title = c.Title
        };
    }

    public static StoredCase FromInterfaceType(
        IStoredCaseWithId c, DateTime? lastEdit = null)
    {
        var result = FromInterfaceTypeNoId(c, lastEdit);
        result.CaseId = c.CaseId;
        return result;
    }
}
