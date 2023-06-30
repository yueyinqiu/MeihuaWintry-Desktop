using MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;
using System.Diagnostics;
using System.Text.Json;
using YiJingFramework.PrimitiveTypes;

var data = new StoredCase(
    lastEdit: DateTime.Now,
    title: "title here",
    owner: "Zombie",
    ownerDescription: "I anm a zombie",
    westernTime: new(DateTime.Now),
    chineseSolarTime: new(Tiangan.Jia, Dizhi.Mao, null, null, null, null, null, null),
    chineseLunarTime: null,
    numbers: new[] { 22, 31, 31 },
    guas: new[] { Gua.Parse("001010"), Gua.Parse("111"), Gua.Parse("101") },
    notes: "Hellow World",
    tags: new[] { "success", "faild" });
var s = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

var dataBack = JsonSerializer.Deserialize<StoredCase>(s);
Debug.Assert(dataBack is not null); // 如果 s 就是字符串 "null" ，它会返回 null 的……

Console.WriteLine(dataBack.Title);
Console.WriteLine(dataBack.LastEdit.ToString());
Console.WriteLine(dataBack.WesternTime?.Time.ToString());
Console.WriteLine(dataBack.ChineseSolarTime);

Console.ReadKey();
