using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging;
public sealed class CaseStore : IDisposable
{
    private readonly LiteDatabase database;
    public FileInfo File { get; }
    public CaseStore(FileInfo databaseFileInfo)
    {
        this.database = new LiteDatabase(databaseFileInfo.FullName, new BsonMapper() {
            SerializeNullValues = true,
            EmptyStringToNull = false,
            EnumAsInteger = true,
            IncludeFields = false,
            IncludeNonPublic = false,
            TrimWhitespace = false
        });
        this.File = databaseFileInfo;
        this.Cases = new CaseManager(this.database);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }

    public ICaseManager Cases { get; }
    public ISettingsManager Settings => throw new NotImplementedException();
    public IAnnotationManager Annotations => throw new NotImplementedException();
    public IDivinerManager Diviners => throw new NotImplementedException();
}
