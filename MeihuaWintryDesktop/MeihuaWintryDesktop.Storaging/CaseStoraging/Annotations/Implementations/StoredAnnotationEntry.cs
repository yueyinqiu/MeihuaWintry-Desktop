using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
internal sealed class StoredAnnotationEntry
{
    public required ObjectId? EntryId { get; set; }
    public required Gua? Gua { get; set; }
    public required string? Annotation { get; set; }
}
