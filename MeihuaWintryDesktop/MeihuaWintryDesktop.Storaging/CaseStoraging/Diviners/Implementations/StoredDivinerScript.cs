using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;

internal sealed class StoredDivinerScript
{
    [BsonId(autoId: false)]
    public required DivinerScriptCategory ScriptId { get; set; }
    public required string? Codes { get; set; }
}
