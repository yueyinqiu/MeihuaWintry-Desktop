using LiteDB;
using LiteDB.Engine;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
public sealed class CaseManager : ICaseManager
{
    private readonly BsonMapper mapper;
    private readonly ILiteCollection<StoredCase> collection;
    internal CaseManager(LiteDatabase database)
    {
        this.mapper = database.Mapper;
        mapper.RegisterType<Tiangan>(
            (x) => x.Index,
            (b) => new(b));
        mapper.RegisterType<Dizhi>(
            (x) => x.Index,
            (b) => new(b));
        mapper.RegisterType<Gua>(
            (x) => x.ToBytes(),
            (b) => Gua.FromBytes(b));

        var collection = database.GetCollection<StoredCase>();
        this.collection = collection;
    }

    public IEnumerable<IStoredCaseWithId> ListCasesByLastEdit()
    {
        return collection.Query()
            .OrderByDescending(s => s.LastEdit)
            .ToEnumerable();
    }

    public IStoredCaseWithId? GetCase(ObjectId id)
    {
        return collection.FindById(id);
    }

    public IStoredCaseWithId InsertCase(IStoredCase c)
    {
        var caseToInsert = StoredCase.FromInterfaceTypeNoId(c);
        var id = collection.Insert(caseToInsert);
        caseToInsert.CaseId = id;
        return caseToInsert;
    }

    public void UpdateCase(IStoredCaseWithId c)
    {
        var caseToUpdate = StoredCase.FromInterfaceType(c);
        bool r = collection.Upsert(caseToUpdate);
        Debug.Assert(r is true);
    }
}
