using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

internal sealed class CaseCreationResult : IStoredCase
{
    public CaseCreationResult(
        string title, string owner, string ownerDescription,
        TheThreeTimes times, List<NumberOfCase?> numbers, List<GuaOfCase?> guas, string notes,
        List<string?> tags)
    {
        this.Title = title;
        this.Owner = owner;
        this.OwnerDescription = ownerDescription;
        this.Notes = notes;

        this.GregorianTime = times.GregorianTime;
        this.ChineseSolarTime = times.ChineseSolarTime;
        this.ChineseLunarTime = times.ChineseLunarTime;

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

    public GregorianTime GregorianTime { get; }
    public ChineseSolarTime ChineseSolarTime { get; }
    public ChineseLunarTime ChineseLunarTime { get; }

    IStoredGregorianTime IStoredCase.GregorianTime => this.GregorianTime;
    IStoredChineseSolarTime IStoredCase.ChineseSolarTime => this.ChineseSolarTime;
    IStoredChineseLunarTime IStoredCase.ChineseLunarTime => this.ChineseLunarTime;

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