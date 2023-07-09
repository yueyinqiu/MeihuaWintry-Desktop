using LiteDB;
using System.Diagnostics;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners.Implementations;
public sealed class DivinerManager : IDivinerManager
{
    private readonly ILiteCollection<StoredDivinerScript> scriptCollection;
    private readonly ILiteCollection<StoredDivinerReference> referenceCollection;
    internal DivinerManager(LiteDatabase database)
    {
        this.scriptCollection = database.GetCollection<StoredDivinerScript>(CollectionNames.DivinerScript);
        this.referenceCollection = database.GetCollection<StoredDivinerReference>(CollectionNames.DivinerReferences);
    }

    public string DivinerScript
    {
        get
        {
            var result = this.scriptCollection.FindById(StoredDivinerScript.PossibleId);
            return result?.Codes ?? "";
        }
        set
        {
            this.scriptCollection.Upsert(new StoredDivinerScript() {
                Codes = value
            });
        }
    }

    public ObjectId AddReference(byte[] content)
    {
        return this.referenceCollection.Insert(new StoredDivinerReference() {
            ReferenceId = null,
            Content = content
        });
    }

    public void RemoveReference(ObjectId id)
    {
        this.referenceCollection.Delete(id);
    }

    public IEnumerable<ObjectId> EnumerateReferenceIds()
    {
        var result = this.referenceCollection
            .Query()
            .Where(x => x.Content != null)
            .Select(x => x.ReferenceId)
            .ToEnumerable();
#pragma warning disable CS8619
        Debug.Assert(result.All(x => x is not null));
        return result;
#pragma warning restore CS8619
    }

    public IEnumerable<(ObjectId id, byte[] content)> EnumerateReferences()
    {
        foreach (var r in this.referenceCollection.FindAll())
        {
            if (r.Content is not null)
            {
                Debug.Assert(r.ReferenceId is not null);
                yield return (r.ReferenceId, r.Content);
            }
        }
    }
}
