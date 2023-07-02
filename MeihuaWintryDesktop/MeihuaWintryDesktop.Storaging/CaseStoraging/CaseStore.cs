using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging;
public sealed class CaseStore : IDisposable
{
    private readonly LiteDatabase database;
    public CaseStore(FileInfo fileInfo)
    {
        var mapper = new BsonMapper();
        // 可以使用这个 mapper 来设置一些特殊类型的序列化方案

        this.database = new LiteDatabase(fileInfo.FullName, mapper);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }
}
