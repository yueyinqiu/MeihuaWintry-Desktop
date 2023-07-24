using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record NumberOfCase(
    string Name,
    int Number) : IStoredNumber
{
}
