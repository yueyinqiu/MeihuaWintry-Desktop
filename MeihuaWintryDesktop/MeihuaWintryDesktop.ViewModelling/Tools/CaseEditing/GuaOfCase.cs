using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed record GuaOfCase(
    string Name,
    Gua Gua, string? AnnotationKey) : IStoredGua
{
}
