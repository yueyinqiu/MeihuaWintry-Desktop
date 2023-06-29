using MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
using System.Diagnostics;
using System.Text.Json;

var data = new StoredCase("title here", null);
var s = JsonSerializer.Serialize(data);

var dataBack = JsonSerializer.Deserialize<StoredCase>(s);
Debug.Assert(dataBack is not null); // 如果 s 就是字符串 "null" ，它会返回 null 的……

Console.WriteLine(dataBack?.Title);
Console.WriteLine(dataBack?.WesternTime is null);