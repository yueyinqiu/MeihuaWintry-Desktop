using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging;
public sealed class CaseStore : IDisposable
{
    private readonly LiteDatabase database;
    public CaseStore(FileInfo databaseFileInfo)
    {
        this.database = new LiteDatabase(databaseFileInfo.FullName, new BsonMapper());
        this.File = databaseFileInfo;
        this.Cases = new CaseManager(this.database);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }

    public FileInfo File { get; }
    public ICaseManager Cases { get; }
    public ISettingsManager Settings => throw new NotImplementedException();
}
