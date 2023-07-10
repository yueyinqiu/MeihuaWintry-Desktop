using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.StoragingTests.GlobalConfiguring.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring.Tests;

[TestClass()]
public class GlobalConfigurationTests
{
    static GlobalConfigurationTests()
    {
        var path = Path.GetFullPath("test configs", Environment.CurrentDirectory);
        var dir = new DirectoryInfo(path);
        if (dir.Exists)
            dir.Delete(true);
    }

    private static CaseStore NewConfiguration()
    {
        for (; ; )
        {
            var path = Path.GetFullPath("test configs", Environment.CurrentDirectory);
            path = Path.GetFullPath(Path.GetRandomFileName(), path);
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
                return new CaseStore(file);
        }
    }

    [TestMethod()]
    public void GlobalConfigurationTest()
    {
        var path = Path.GetFullPath("test configs", Environment.CurrentDirectory);
        path = Path.GetFullPath("configs.db", path);
        FileInfo file = new FileInfo(path);

        using var configuration = new GlobalConfiguration(file);
        configuration.AccessHistorys.SetHistory(new AccessHistory() {
            File = new FileInfo("abc.mhw"),
            IsTrusted = true,
            LastAccess = DateTime.Now,
        });
        file.Delete();
        configuration.AccessHistorys.SetHistory(new AccessHistory() {
            File = new FileInfo("abcd.mhw"),
            IsTrusted = false,
            LastAccess = DateTime.Now + new TimeSpan(0, 1, 0)
        });
        configuration.AccessHistorys.SetHistory(new AccessHistory() {
            File = new FileInfo("abcde.mhw"),
            IsTrusted = true,
            LastAccess = DateTime.Now + new TimeSpan(0, 1, 1)
        });
        Assert.AreEqual(null, configuration.AccessHistorys.TryGetHistory(new FileInfo("abc.mhw")));
        Assert.AreEqual(false, configuration.AccessHistorys.TryGetHistory(new FileInfo("abcd.mhw")).IsTrusted);

        var arr = configuration.AccessHistorys.ListHistorysByLastAccess().ToArray();
        Assert.AreEqual(2, arr.Length);
        Assert.AreEqual(new FileInfo("abcde.mhw").FullName, arr[0].File.FullName);
    }
}