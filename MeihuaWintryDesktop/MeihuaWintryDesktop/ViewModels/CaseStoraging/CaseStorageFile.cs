using LiteDB;
using System;
using System.IO;

namespace MeihuaWintryDesktop.ViewModels.CaseStoraging;

public sealed class CaseStorageFile : IDisposable
{
    private readonly LiteDatabase database;
    public CaseStorageFile(FileInfo path)
    {
        var connectionString = new ConnectionString() {
             Filename = path.FullName
        };
        this.database = new LiteDatabase(connectionString);
    }

    public void Dispose()
    {
        this.database.Dispose();
    }
}