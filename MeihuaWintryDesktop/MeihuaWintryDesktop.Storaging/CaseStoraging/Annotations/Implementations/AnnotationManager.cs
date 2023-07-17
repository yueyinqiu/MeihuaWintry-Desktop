using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
public sealed class AnnotationManager : IAnnotationManager
{
    private readonly ILiteCollection<StoredAnnotationEntry> collection;
    internal AnnotationManager(LiteDatabase database)
    {
        this.collection = database.GetCollection<StoredAnnotationEntry>(CollectionNames.Annotations);
    }

    public string? this[string key]
    {
        get
        {
            var result = this.collection.FindById(key);
            return result?.Annotation;
        }
        set
        {
            if (value is null)
            {
                _ = this.collection.Delete(key);
                return;
            }
            this.collection.Upsert(new StoredAnnotationEntry() {
                Key = key,
                Annotation = value
            });
        }
    }

    public IEnumerable<(string key, string annotation)> Enumerate()
    {
        foreach (var entry in this.collection.FindAll())
        {
            if (entry.Annotation is null || entry.Key is null)
                continue;
            yield return (entry.Key, entry.Annotation);
        }
    }
}
