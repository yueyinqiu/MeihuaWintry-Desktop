using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging;
public sealed class CaseStore : IDisposable
{
    private readonly LiteDatabase database;
    public CaseStore(FileInfo fileInfo)
    {
        this.database = new LiteDatabase(fileInfo.FullName, new BsonMapper());
        this.Cases = new CaseManager(this.database);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }

    public CaseManager Cases { get; }
}
