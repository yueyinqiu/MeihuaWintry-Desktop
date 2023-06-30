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
        ChineseSolarTime? solarTime,
        ChineseLunarTime? lunarTime,
        string? description,
        string? guaMaster,
        string? guaMasterDescription,
        IReadOnlyList<int> guaNumber,
        Gua?[] gua
        )
    {
        Title = title ?? "";
        OpenTime = openTime;
        Notes = description ?? "";
        Tags = tags;
        WesternTime = westernTime;
        ChineseSolarTime = solarTime;
        ChineseLunarTime = lunarTime;
        GuaOwner = guaMaster?? "";
        GuaOwnerNotes = guaMasterDescription ?? "";
        GuaNumbers = guaNumber;
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
