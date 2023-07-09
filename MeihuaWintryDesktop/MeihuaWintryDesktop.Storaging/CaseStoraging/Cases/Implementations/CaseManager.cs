using LiteDB;
using System.Diagnostics;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
public sealed class CaseManager : ICaseManager
{
    private readonly BsonMapper mapper;
    private readonly ILiteCollection<StoredCase> collection;
    internal CaseManager(LiteDatabase database)
    {
        this.mapper = database.Mapper;
        this.mapper.RegisterType<Tiangan>(
            (x) => x.Index,
            (b) => new(b));
        this.mapper.RegisterType<Dizhi>(
            (x) => x.Index,
            (b) => new(b));
        this.mapper.RegisterType<Gua>(
            (x) => x.ToBytes(),
            (b) => Gua.FromBytes(b));

        this.collection = database.GetCollection<StoredCase>(CollectionNames.Cases);
    }

    public IEnumerable<IStoredCaseWithId> ListCasesByLastEdit()
    {
        return this.collection.Query()
            .OrderByDescending(s => s.LastEdit)
            .ToEnumerable();
    }

    public IStoredCaseWithId? GetCase(ObjectId id)
    {
        return this.collection.FindById(id);
    }

    public IStoredCaseWithId InsertCase(IStoredCase c)
    {
        var caseToInsert = StoredCase.FromInterfaceTypeNoId(c);
        var id = this.collection.Insert(caseToInsert);
        caseToInsert.CaseId = id;
        return caseToInsert;
    }

    public void UpdateCase(IStoredCaseWithId c)
    {
        var caseToUpdate = StoredCase.FromInterfaceType(c);
        bool r = this.collection.Upsert(caseToUpdate);
        Debug.Assert(r is true);
    }
}
