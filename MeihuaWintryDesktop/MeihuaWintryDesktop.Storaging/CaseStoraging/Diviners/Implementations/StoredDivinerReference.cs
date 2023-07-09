using LiteDB;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;

internal sealed class StoredDivinerReference
{
    [BsonId]
    public required ObjectId? ReferenceId { get; set; }
    public required byte[]? Content { get; set; }
}
