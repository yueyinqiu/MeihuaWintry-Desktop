using LiteDB;
using System.Diagnostics.CodeAnalysis;

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

    public required DateTime LastEdit { get; set; }

    private string title;
    public required string Title
    {
        get => this.title;
        [MemberNotNull(nameof(title))]
        set => this.title = value ?? "";
    }

    private string owner;
    public required string Owner
    {
        get => this.owner;
        [MemberNotNull(nameof(owner))]
        set => this.owner = value ?? "";
    }

    private string ownerDescription;
    public required string OwnerDescription
    {
        get => this.ownerDescription;
        [MemberNotNull(nameof(ownerDescription))]
        set => this.ownerDescription = value ?? "";
    }

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

    private string notes;
    public required string Notes
    {
        get => this.notes;
        [MemberNotNull(nameof(notes))]
        set => this.notes = value ?? "";
    }
    public required string?[]? Tags { get; set; }
    IEnumerable<string> IStoredCase.Tags => SelectNotNull(this.Tags);

    public static StoredCase FromInterfaceTypeNoId(
        IStoredCase c, DateTime? lastEdit = null)
    {
        return new StoredCase() {
            CaseId = ObjectId.Empty,
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
