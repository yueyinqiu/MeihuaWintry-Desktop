using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;

internal sealed class StoredGregorianTime : IStoredGregorianTime
{
    public required int? Year { get; set; }
    public required int? Month { get; set; }
    public required int? Day { get; set; }
    public required int? Hour { get; set; }
    public required int? Minute { get; set; }

    public override string ToString()
    {
        static string ToString(int? i)
        {
            return i?.ToString() ?? "[null]";
        }
        return
            $"{ToString(this.Year)}/{ToString(this.Month)}/{ToString(this.Day)} " +
            $"{ToString(this.Year)}:{ToString(this.Year)}";
    }


    public static StoredGregorianTime Empty
    {
        get
        {
            return new() {
                Month = null,
                Day = null,
                Year = null,
                Hour = null,
                Minute = null
            };
        }
    }

    public static StoredGregorianTime FromInterfaceType(IStoredGregorianTime t)
    {
        return new StoredGregorianTime() {
            Month = t.Month,
            Day = t.Day,
            Year = t.Year,
            Hour = t.Hour,
            Minute = t.Minute
        };
    }
}
