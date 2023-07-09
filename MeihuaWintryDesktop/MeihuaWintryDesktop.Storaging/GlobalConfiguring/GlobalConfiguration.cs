using LiteDB;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys.Implementations;
using System.Globalization;

namespace MeihuaWintryDesktop.Storaging.GlobalConfiguring;
public sealed class GlobalConfiguration : IDisposable
{
    private readonly LiteDatabase database;
    public GlobalConfiguration(FileInfo databaseFileInfo)
    {
        var connectionString = new ConnectionString() {
            Filename = databaseFileInfo.FullName,
            Connection = ConnectionType.Shared,
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

        this.AccessHistorys = new AccessHistoryManager(this.database);
    }
    public void Dispose()
    {
        this.database.Dispose();
    }

    public IAccessHistoryManager AccessHistorys { get; }
}
