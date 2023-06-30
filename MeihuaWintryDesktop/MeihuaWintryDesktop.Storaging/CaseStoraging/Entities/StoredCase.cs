using System.Text.Json;
using System.Text.Json.Serialization;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

public sealed class StoredCase
{
    [JsonConstructor]
    public StoredCase(
        string? title,
        OpenTime? openTime,
        IReadOnlyList<string> tags,
        WesternTime? westernTime,
        ChineseSolarTime? chineseSolarTime,
        ChineseLunarTime? chineseLunarTime,
        string? notes,
        string? guaOwner,
        string? guaOwnerNotes,
        IReadOnlyList<int> guaNumbers,
        Gua?[] gua
        )
    {
        Title = title ?? "";
        OpenTime = openTime;
        Notes = notes ?? "";
        Tags = tags;
        WesternTime = westernTime;
        ChineseSolarTime = chineseSolarTime;
        ChineseLunarTime = chineseLunarTime;
        GuaOwner = guaOwner?? "";
        GuaOwnerNotes = guaOwnerNotes ?? "";
        GuaNumbers = guaNumbers;
        Guas = gua;
    }

    public OpenTime? OpenTime { get; }
    public string Title { get; }
    public IReadOnlyList<string> Tags { get; }
    public WesternTime? WesternTime { get; }
    public ChineseSolarTime? ChineseSolarTime { get; }
    public ChineseLunarTime? ChineseLunarTime { get; }
    public string Notes { get; }
    public string GuaOwner { get; }
    public string GuaOwnerNotes { get; }
    public IReadOnlyList<int> GuaNumbers { get; }
    public Gua?[] Guas {get;}
}
