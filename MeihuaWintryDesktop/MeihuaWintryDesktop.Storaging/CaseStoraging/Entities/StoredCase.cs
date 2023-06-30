using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

public sealed class StoredCase
{
    [JsonConstructor]
    public StoredCase(
        DateTime lastEdit,
        string? title,
        string? owner,
        string? ownerDescription,
        WesternTime? westernTime,
        ChineseSolarTime? chineseSolarTime,
        ChineseLunarTime? chineseLunarTime,
        IReadOnlyList<int>? numbers,
        IReadOnlyList<Gua?>? guas,
        string? notes,
        IReadOnlyList<string?>? tags)
    {
        static IReadOnlyList<T> AsNotNull<T>(IEnumerable<T?>? items) where T : class
        {
            if (items is null)
                return Array.Empty<T>();

            var result = new List<T>();
            foreach (var item in items)
            {
                if (item is not null)
                    result.Add(item);
            }
            return result;
        }

        this.LastEdit = lastEdit;

        this.Title = title ?? "";

        this.Owner = owner ?? "";
        this.OwnerDescription = ownerDescription ?? "";

        this.WesternTime = westernTime;
        this.ChineseSolarTime = chineseSolarTime ?? 
            new(null, null, null, null, null, null, null, null);
        this.ChineseLunarTime = chineseLunarTime ?? new();

        this.Numbers = numbers ?? Array.Empty<int>();
        this.Guas = AsNotNull(guas);

        this.Notes = notes ?? "";
        this.Tags = AsNotNull(tags);
    }

    public DateTime LastEdit { get; }

    public string Title { get; }

    public string Owner { get; }
    public string OwnerDescription { get; }

    public WesternTime? WesternTime { get; }
    public ChineseSolarTime ChineseSolarTime { get; }
    public ChineseLunarTime ChineseLunarTime { get; }

    public IReadOnlyList<int> Numbers { get; }
    public IReadOnlyList<Gua> Guas { get; }

    public string Notes { get; }
    public IReadOnlyList<string> Tags { get; }
}
