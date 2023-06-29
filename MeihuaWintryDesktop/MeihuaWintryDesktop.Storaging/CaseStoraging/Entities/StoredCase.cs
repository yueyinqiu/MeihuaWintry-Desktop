using System.Text.Json;
using System.Text.Json.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

public sealed class StoredCase
{
    [JsonConstructor]
    public StoredCase(string? title, StoredWesternTime? westernTime)
    {
        Title = title ?? "";
        WesternTime = westernTime;
    }

    public string Title { get; }
    public StoredWesternTime? WesternTime { get; }
}
