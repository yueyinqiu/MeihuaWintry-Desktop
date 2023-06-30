using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YiJingFramework.PrimitiveTypes.Serialization;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
[JsonConverter(typeof(JsonConverterOfStringConvertibleForJson<ChineseLunarTime>))]
public sealed record ChineseLunarTime(int? LunarMonth,int? LunarDay) : IStringConvertibleForJson<ChineseLunarTime>
{
    public string ToStringForJson()
    {
        string lunarTime = "";
        if (LunarMonth != null)
            lunarTime += $"{LunarMonth} Month ";
        if (LunarDay != null)
            lunarTime += $"{LunarDay} Day";
        return lunarTime;
    }

    public static bool FromStringForJson(string s, [MaybeNullWhen(false)] out ChineseLunarTime result)
    {
        var splitOFS = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int lunarMonth;
        int lunarDay;
        if (splitOFS.Length != 4)
        {
            result = null;
            return false;
        }
        int.TryParse(splitOFS[0],out lunarMonth);
        if (splitOFS[1] != "Month")
        {
            result = null;
            return false;
        }
        int.TryParse(splitOFS[2],out lunarDay);
        if (splitOFS[3] != "Day")
        {
            result = null;
            return false;
        }
        result = new(lunarMonth, lunarDay);
        return true;
    }

    public override string ToString()
    {
        static string OneBitNumberToChinese(int num)
        {
            if (num == 0)
                return "";
            string chinesestr = "一二三四五六七八九十";
            return chinesestr.Substring(num - 1, 1);
        }
        string lunarMonth = "";
        string lunarDay = "";
        if (LunarMonth != null)
        {
            if (LunarMonth == 1)
                lunarMonth = "正";
            else if (LunarMonth <= 10)
                lunarMonth += OneBitNumberToChinese((int)this.LunarMonth);
            else
                lunarMonth += "十" + OneBitNumberToChinese((int)this.LunarMonth - 10);
            lunarMonth += "月";
        }
        if (LunarDay != null)
            if (LunarDay <= 10)
                lunarDay += "初" + OneBitNumberToChinese((int)this.LunarDay);
            else if (LunarDay > 10 && LunarDay <= 20)
                lunarDay += "十" + OneBitNumberToChinese((int)this.LunarDay - 10);
            else
                lunarDay += "廿" + OneBitNumberToChinese((int)this.LunarDay - 20);
        if (lunarDay != "" || lunarMonth != "")
            return $"{lunarMonth}{lunarDay}";
        else
            return "Null";
    }
}
