using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
internal sealed class StoredAnnotationEntry
{
    [BsonId(autoId: false)]
    public required string? Key { get; set; }
    public required string? Annotation { get; set; }
}
