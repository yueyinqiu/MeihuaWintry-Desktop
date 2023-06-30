using MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
using System.Diagnostics;
using System.Text.Json;

var data = new StoredCase(
    "title here", 
    null,
    new[]{"success","faild"},
    new(DateTime.Now),
    null,null, 
    "Hellow World",
    "Zombie",
    "I anm a zombie",
    null,null);
var s = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true});

var dataBack = JsonSerializer.Deserialize<StoredCase>(s);
Debug.Assert(dataBack is not null); // 如果 s 就是字符串 "null" ，它会返回 null 的……

Console.WriteLine(dataBack?.Title);
Console.WriteLine(dataBack?.OpenTime.ToString());
Console.WriteLine(dataBack?.WesternTime.Time.ToString());

Console.ReadKey();