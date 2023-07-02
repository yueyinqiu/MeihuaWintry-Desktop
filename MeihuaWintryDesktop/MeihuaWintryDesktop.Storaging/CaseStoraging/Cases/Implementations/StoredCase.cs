using LiteDB;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

    public required ObjectId? CaseId { get; set; }
    ObjectId IStoredCaseWithId.CaseId => this.CaseId ?? ObjectId.Empty;

    public required DateTime LastEdit { get; set; }

    public required string? Title { get; set; }
    string IStoredCase.Title => this.Title ?? "";

    public required string? Owner { get; set; }
    string IStoredCase.Owner => this.Owner ?? "";
    public required string? OwnerDescription { get; set; }
    string IStoredCase.OwnerDescription => this.OwnerDescription ?? "";

    public required GregorianTime? GregorianTime { get; set; }
    IGregorianTime IStoredCase.GregorianTime => this.GregorianTime ?? GregorianTime.Empty;
    public required ChineseSolarTime? ChineseSolarTime { get; set; }
    IChineseSolarTime IStoredCase.ChineseSolarTime => this.ChineseSolarTime ?? ChineseSolarTime.Empty;
    public required ChineseLunarTime? ChineseLunarTime { get; set; }
    IChineseLunarTime IStoredCase.ChineseLunarTime => this.ChineseLunarTime ?? ChineseLunarTime.Empty;

    public required NamedStruct<int>?[]? Numbers { get; set; }
    IEnumerable<INamed<int>> IStoredCase.Numbers => SelectNotNull(this.Numbers);
    public required NamedGua?[]? Guas { get; set; }
    IEnumerable<INamed<Gua>> IStoredCase.Guas => SelectNotNull(this.Guas);

    public required string? Notes { get; set; }
    string IStoredCase.Notes => this.Notes ?? "";
    public required string?[]? Tags { get; set; }
    IEnumerable<string> IStoredCase.Tags => SelectNotNull(this.Tags);

    public static StoredCase FromInterfaceTypeNoId(
        IStoredCase c, DateTime? lastEdit = null)
    {
        return new StoredCase() {
            CaseId = null,
            ChineseLunarTime = ChineseLunarTime.FromInterfaceType(c.ChineseLunarTime),
            ChineseSolarTime = ChineseSolarTime.FromInterfaceType(c.ChineseSolarTime),
            GregorianTime = GregorianTime.FromInterfaceType(c.GregorianTime),
            Guas = c.Guas.Select(NamedGua.FromInterfaceType).ToArray(),
            LastEdit = lastEdit ?? DateTime.Now,
            Notes = c.Notes,
            Numbers = c.Numbers.Select(NamedStruct<int>.FromInterfaceType).ToArray(),
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
