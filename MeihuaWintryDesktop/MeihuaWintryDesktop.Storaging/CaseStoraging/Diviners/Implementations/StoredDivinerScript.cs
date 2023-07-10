using LiteDB;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;

internal sealed class StoredDivinerScript
{
    [BsonId(autoId: false)]
    public required int ScriptId { get; set; }
    public required string? Codes { get; set; }
}
