using LiteDB;
using MeihuaWintryDesktop.StoragingTests.CaseStoraging.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Tests;

[TestClass()]
public class CaseStoreTests
{
    static CaseStoreTests()
    {
        var path = Path.GetFullPath("test stores", Environment.CurrentDirectory);
        var dir = new DirectoryInfo(path);
        try
        {
            if (dir.Exists)
                dir.Delete(true);
        }
        catch { }
    }

    private static CaseStore NewStore()
    {
        for (; ; )
        {
            var path = Path.GetFullPath("test stores", Environment.CurrentDirectory);
            path = Path.GetFullPath(Path.GetRandomFileName(), path);
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
                return new CaseStore(file);
        }
    }

    [TestMethod()]
    public void CaseStoreTest()
    {
        var path = Path.GetFullPath("test stores", Environment.CurrentDirectory);
        path = Path.GetFullPath("hello world.mhw", path);
        FileInfo file = new FileInfo(path);

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
                    Gua = Gua.Parse("011"),
                    AnnotationKey = "GUA011011",
                    Name = "GUA011"
                },
                new StoredGua() {
                    Gua = null,
                    AnnotationKey = "GUA1",
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

        Assert.AreNotEqual(cIn.Guas.ElementAt(1).Gua, cOut.Guas.ElementAt(1).Gua);
        Assert.AreEqual(Gua.Parse(""), cOut.Guas.ElementAt(1).Gua);

        cIn.CaseId = cOut.CaseId;
        cIn.OwnerDescription = null;
        store.Cases.InsertCase(cOut);
        store.Cases.UpdateCase(cIn);

        store.Cases.InsertCase(cOut);
        store.Cases.InsertCase(cOut);
        cOut = store.Cases.InsertCase(cOut);

        Assert.AreEqual("GUAZHUSHIJIANGSHI", cOut.OwnerDescription);

        var cases = store.Cases.CreateQuery().OrderByLastEdit(true).Query();
        Assert.AreEqual("", cases.ToArray()[3].OwnerDescription);
    }

    [TestMethod()]
    public void AnnotationTest()
    {
        using var store = NewStore();

        store.Annotations["GUA"] = "";
        store.Annotations["GUA1111"] = "1111";
        store.Annotations["GUA001"] = "GUA001";

        var all = store.Annotations.Enumerate().ToDictionary(x => x.key, x => x.annotation);
        Assert.AreEqual(3, all.Count);
        Assert.AreEqual("", all["GUA"]);
        Assert.AreEqual("GUA001", all["GUA001"]);
        Assert.AreEqual(all["GUA1111"], store.Annotations["GUA1111"]);
        Assert.AreEqual(null, store.Annotations["GUA111111111111"]);

        store.Annotations["GUA001"] = null;

        all = store.Annotations.Enumerate().ToDictionary(x => x.key, x => x.annotation);
        Assert.AreEqual(2, all.Count);
        Assert.AreEqual(null, store.Annotations["GUA001"]);
    }

    [TestMethod()]
    public void SettingsTest()
    {
        using var store = NewStore();

        store.Settings.StoreNotes = "ABC";
        Assert.AreEqual("ABC", store.Settings.StoreNotes);

        store.Settings.StoreNotes = null;
        Assert.AreEqual("", store.Settings.StoreNotes);
    }

    [TestMethod()]
    public void DivinerTest()
    {
        using var store = NewStore();

        store.Diviners.SetScript(Diviners.DivinerScriptCategory.DefaultScript, "ABC");
        Assert.AreEqual("ABC", store.Diviners.GetScript(Diviners.DivinerScriptCategory.DefaultScript));
        Assert.AreEqual("", store.Diviners.GetScript(Diviners.DivinerScriptCategory.PreScript));

        store.Diviners.SetScript(Diviners.DivinerScriptCategory.DefaultScript, null);
        Assert.AreEqual("", store.Diviners.GetScript(Diviners.DivinerScriptCategory.DefaultScript));
    }
}