using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Settings;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Settings.Implementations;
using System.Globalization;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging;
public sealed class CaseStore : IDisposable
{
    private readonly LiteDatabase database;
    public FileInfo File { get; }
    public CaseStore(FileInfo databaseFileInfo)
    {
        var connectionString = new ConnectionString() {
            Filename = databaseFileInfo.FullName,
            Connection = ConnectionType.Direct,
            Collation = new Collation(CultureInfo.InvariantCulture.LCID, CompareOptions.Ordinal)
        };
        var bsonMapper = new BsonMapper() {
            SerializeNullValues = true,
            EmptyStringToNull = false,
            EnumAsInteger = true,
            IncludeFields = false,
            IncludeNonPublic = false,
            TrimWhitespace = false
        };

        databaseFileInfo.Directory?.Create();
        this.database = new LiteDatabase(connectionString, bsonMapper);

        this.File = databaseFileInfo;
        this.Cases = new CaseManager(this.database);
        this.Settings = new SettingsManager(this.database);
        this.Annotations = new AnnotationManager(this.database);
        this.Diviners = new DivinerManager(this.database);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }

    public ICaseManager Cases { get; }
    public ISettingsManager Settings { get; }
    public IAnnotationManager Annotations { get; }
    public IDivinerManager Diviners { get; }
}
