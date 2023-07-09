using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations;
public interface IAnnotationManager
{
    string? this[Gua gua] { get; set; }

    IEnumerable<(Gua gua, string annotation)> Enumerate();
}
