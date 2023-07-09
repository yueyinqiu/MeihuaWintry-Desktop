using LiteDB;
using MeihuaWintryDesktop.StoragingTests.CaseStoraging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Tests;

[TestClass()]
public class CaseStoreTests
{
    private static CaseStore NewStore()
    {
        var path = Path.GetFullPath("test stores", Environment.CurrentDirectory);
        path = Path.GetFullPath(Path.GetRandomFileName(), path);
        FileInfo file = new FileInfo(path);
        if (file.Exists)
            file.Delete();
        return new CaseStore(file);
    }

    [TestMethod()]
    public void CaseStoreTest()
    {
        var path = Path.GetFullPath("test stores", Environment.CurrentDirectory);
        path = Path.GetFullPath("hello world.mhw", path);
        FileInfo file = new FileInfo(path);
        if (file.Exists)
            file.Delete();

        using var store = new CaseStore(file);
        Assert.AreEqual(file.FullName, store.File.FullName);

        using var store0 = NewStore();
        using (var store1 = NewStore())
        {
            using var store2 = NewStore();
            using var store3 = NewStore();
        }
        using var store4 = NewStore();

        _ = Assert.ThrowsException<IOException>(store0.File.Delete);
        store0.Dispose();
        store0.File.Delete();
    }

    [TestMethod()]
    public void CaseTest()
    {
        using var store = NewStore();
        var time = new AnyTime() {
            Day = null,
            Month = -1213,
            TimeGan = Tiangan.Gui,
            TimeZhi = null,
            YearGan = null,
            YearZhi = Dizhi.Si,
            DayGan = Tiangan.Ren,
            DayZhi = null,
            MonthGan = null,
            MonthZhi = Dizhi.Chou,
            Hour = 1232,
            Minute = null,
            Year = 0
        };
        var cIn = new Case() {
            CaseId = ObjectId.NewObjectId(),
            ChineseLunarTime = time,
            ChineseSolarTime = time,
            GregorianTime = time,
            Guas = new[] {
                new StoredGua() {
                    Display = Gua.Parse("011"),
                    Gua = Gua.Parse("011011"),
                    Name = "GUA011"
                },
                new StoredGua() {
                    Display = null,
                    Gua = Gua.Parse("1"),
                    Name = null
                },
            },
            Notes = "NOOOOTES",
            Numbers = new[] {
                new StoredNumber() {
                    Number = 12312,
                    Name = "NUMBER12312"
                },
                new StoredNumber() {
                    Number = -1,
                    Name = null
                },
            },
            Owner = "GUAZHU",
            OwnerDescription = "GUAZHUSHIJIANGSHI",
            Tags = new[] {
                "QWQ",
                "QAQ",
                "TAG"
            },
            Title = "TITLE"
        };
        var cOut = store.Cases.InsertCase(cIn);

        Assert.AreNotEqual(cIn.CaseId, cOut.CaseId);
        Assert.AreEqual(cIn.Notes, cOut.Notes);
        Assert.AreEqual(cIn.ChineseLunarTime.Day, cOut.ChineseLunarTime.Day);

        Assert.AreNotEqual(cIn.Guas.ElementAt(1).Display, cOut.Guas.ElementAt(1).Display);
        Assert.AreEqual(Gua.Parse(""), cOut.Guas.ElementAt(1).Display);

        cIn.CaseId = cOut.CaseId;
        cIn.OwnerDescription = null;
        store.Cases.InsertCase(cOut);
        store.Cases.UpdateCase(cIn);

        store.Cases.InsertCase(cOut);
        store.Cases.InsertCase(cOut);
        cOut = store.Cases.InsertCase(cOut);

        Assert.AreEqual("GUAZHUSHIJIANGSHI", cOut.OwnerDescription);

        var cases = store.Cases.ListCasesByLastEdit().ToArray();
        Assert.AreEqual(5, cases.Length);
        Assert.AreEqual("", cases[3].OwnerDescription);
    }
}