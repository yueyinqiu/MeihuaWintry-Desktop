using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
using StoragingTest;
using System;
using YiJingFramework.PrimitiveTypes;


var mapper = new BsonMapper();
mapper.RegisterType(
    (x) => x.ToString(),
    (b) => Tiangan.Parse(b.AsString));
mapper.RegisterType(
    (x) => x.ToString(),
    (b) => Dizhi.Parse(b.AsString));
mapper.RegisterType(
    (x) => x.ToString(),
    (b) => Gua.Parse(b.AsString));


var exp1 = mapper.GetExpression((StoredCase s) => s.Owner);
var exp2 = mapper.GetExpression((IStoredCase s) => s.Owner);

using LiteDatabase liteDatabase = new LiteDatabase("test.db", mapper);
var collection = liteDatabase.GetCollection<StoredCase>("c1");
collection.DeleteAll();

var data = new StoredCase() {
    LastEdit = DateTime.Now,
    ChineseSolarTime = new ChineseSolarTime() {
        YearGan = Tiangan.Jia,
        YearZhi = Dizhi.Mao,
    },
    Guas = new NamedGua[] {
         new NamedGua() {
              Name = "本", Value = Gua.Parse("000000")
         },
         new NamedGua() {
              Name = "互", Value = Gua.Parse("000000")
         },
         new NamedGua() {
              Name = "变", Value = Gua.Parse("000001")
         }
    },
    Notes = "Hello World!",
    Numbers = new NamedStruct<int>[] {
         new NamedStruct<int>() {
              Name = "上卦数", Value = 16
         },
         new NamedStruct<int>() {
              Name = "下卦数", Value = 32
         },
         new NamedStruct<int>() {
              Name = "动爻数", Value = 54
         }
    },
    Owner = "Mr. Zombie",
    OwnerDescription = "It's a zombie.",
    Tags = new string[] {
        "non-living", "zombie", "crazy"
    },
    Title = "ZOMBIE HERE"
};

var id = collection.Insert(data);
var back = collection.FindById(id);

var collectionWeakTyped = liteDatabase.GetCollection("c1");
var backDocument = collectionWeakTyped.FindById(id);

var dataBad = new BadStoredCase() {
    Numbers = new NamedObject[] {
         new NamedObject() {
              Name = "null int", Value = null // 读取时会认为是 0
         },
         new NamedObject() {
              Name = "null int", Value = "qwer" // 读取时会导致异常
         }
    },
    Guas = new NamedObject[] {
         new NamedObject() {
              Name = "null", Value = "qwer" // 读取时会导致异常（ mapper.RegisterType 里的方法决定的）
         }
    }
};
var badId = collectionWeakTyped.Insert(mapper.ToDocument(dataBad));
var backBad = collection.FindById(badId);

Console.ReadKey();