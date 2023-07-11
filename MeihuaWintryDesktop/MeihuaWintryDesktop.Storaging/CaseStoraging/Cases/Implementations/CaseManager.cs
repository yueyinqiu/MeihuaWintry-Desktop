using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
public sealed class CaseManager : ICaseManager
{
    private readonly ILiteCollection<StoredCase> collection;
    internal CaseManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<StoredCase>(CollectionNames.Cases);

        this.collection.EnsureIndex(x => x.LastEdit);
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
        _ = this.collection.Upsert(caseToUpdate);
    }
}
