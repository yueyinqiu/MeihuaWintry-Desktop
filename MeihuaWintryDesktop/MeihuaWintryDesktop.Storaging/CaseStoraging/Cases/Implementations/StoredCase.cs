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

    private ObjectId caseId;
    [BsonId]
    public required ObjectId CaseId
    {
        get => this.caseId;
        [MemberNotNull(nameof(caseId))]
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), $"{nameof(this.CaseId)}  不可以为 null 。");
            this.caseId = value;
        }
    }

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

    public required DateTime DivinationTime { get; set; }
    DateTime? IStoredCase.DivinationTime => this.DivinationTime == default ? null : this.DivinationTime;

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
            DivinationTime = c.DivinationTime ?? default,
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
