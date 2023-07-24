using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseSearching;
public sealed record SearchedCase(IStoredCaseWithId StoredCase, string? SearchDetails)
{
}
