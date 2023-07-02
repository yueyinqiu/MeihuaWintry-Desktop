using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes;
using YiJingFramework.PrimitiveTypes.Serialization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;

internal sealed class ChineseSolarTime : IChineseSolarTime
{
    public Tiangan? YearGan { get; set; }
    public Dizhi? YearZhi { get; set; }
    public Tiangan? MonthGan { get; set; }
    public Dizhi? MonthZhi { get; set; }
    public Tiangan? DayGan { get; set; }
    public Dizhi? DayZhi { get; set; }
    public Tiangan? TimeGan { get; set; }
    public Dizhi? TimeZhi { get; set; }

    public override string ToString()
    {
        static string ToString<T>(T? tianganOrDizhi) where T : struct, IFormattable
        {
            var result = tianganOrDizhi.HasValue ?
                tianganOrDizhi.Value.ToString("C", null)
                : "缺";
            Debug.Assert(result is not null);
            return result;
        }

        return
            $"{ToString(this.YearGan)}{ToString(this.YearZhi)}年 " +
            $"{ToString(this.MonthGan)}{ToString(this.MonthZhi)}月 " +
            $"{ToString(this.DayGan)}{ToString(this.DayZhi)}日 " +
            $"{ToString(this.TimeGan)}{ToString(this.TimeZhi)}时";
    }
}
