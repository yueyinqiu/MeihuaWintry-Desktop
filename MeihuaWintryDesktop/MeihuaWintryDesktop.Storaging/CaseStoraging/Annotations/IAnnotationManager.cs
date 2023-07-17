using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations;
public interface IAnnotationManager
{
    string? this[string key] { get; set; }

    IEnumerable<(string key, string annotation)> Enumerate();
}
