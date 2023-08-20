using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

internal sealed class CaseCreationResult : IStoredCase
{
    public CaseCreationResult(
        string title, string owner, string ownerDescription,
        DateTime? divinationTime, List<NumberOfCase?> numbers, List<GuaOfCase?> guas, string notes,
        List<string?> tags)
    {
        this.Title = title;
        this.Owner = owner;
        this.OwnerDescription = ownerDescription;
        this.Notes = notes;

        this.DivinationTime = divinationTime;

        this.Numbers = numbers;
        this.Guas = guas;
        this.Tags = tags;
    }

    public string? Title { get; set; }
    public string? Owner { get; set; }
    public string? OwnerDescription { get; set; }
    public string? Notes { get; set; }

    string IStoredCase.Title => this.Title ?? "";
    string IStoredCase.Owner => this.Owner ?? "";
    string IStoredCase.OwnerDescription => this.OwnerDescription ?? "";
    string IStoredCase.Notes => this.Notes ?? "";

    public DateTime? DivinationTime { get; set; }

    public List<NumberOfCase?> Numbers { get; }
    public List<GuaOfCase?> Guas { get; }
    public List<string?> Tags { get; }

    private static IEnumerable<T> SelectNotNull<T>(IEnumerable<T?> values)
    {
        foreach (var value in values)
        {
            if (value is not null)
                yield return value;
        }
    }
    IEnumerable<IStoredNumber> IStoredCase.Numbers => SelectNotNull(this.Numbers);
    IEnumerable<IStoredGua> IStoredCase.Guas => SelectNotNull(this.Guas);
    IEnumerable<string> IStoredCase.Tags => SelectNotNull(this.Tags);
}