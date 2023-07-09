using LiteDB;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Settings.Implementations;

internal sealed class Settings
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
