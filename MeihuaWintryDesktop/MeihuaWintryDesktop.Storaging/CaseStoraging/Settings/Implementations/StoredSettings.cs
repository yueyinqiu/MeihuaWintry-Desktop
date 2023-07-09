using LiteDB;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings.Implementations;

internal sealed class StoredSettings
{
    public static int PossibleId => 1;

    [BsonId(autoId: false)]
    public int Id
    {
        get => PossibleId;
        set
        {
            Debug.Assert(value == PossibleId);
        }
    }
    public required string? Notes { get; set; }
}
