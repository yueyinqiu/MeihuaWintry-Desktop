using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
public sealed class AnnotationManager : IAnnotationManager
{
    private readonly BsonMapper bsonMapper;
    private readonly ILiteCollection<StoredAnnotationEntry> collection;
    internal AnnotationManager(LiteDatabase database)
    {
        this.bsonMapper = database.Mapper;
        this.collection = database.GetCollection<StoredAnnotationEntry>(CollectionNames.Annotations);
    }

    public string? this[Gua gua]
    {
        get
        {
            var id = this.bsonMapper.Serialize(gua);
            var result = this.collection.FindById(id);
            return result?.Annotation;
        }
        set
        {
            if (value is null)
            {
                this.collection.DeleteMany(x => x.Gua == gua);
                return;
            }
            var updateResult = this.collection.UpdateMany(x => new StoredAnnotationEntry() {
                Gua = x.Gua,
                Annotation = value
            }, x => x.Gua == gua);
            if (updateResult is 0)
            {
                this.collection.Insert(new StoredAnnotationEntry() {
                    Gua = gua,
                    Annotation = value
                });
            }
        }
    }

    public IEnumerable<(Gua gua, string annotation)> Enumerate()
    {
        foreach (var entry in this.collection.FindAll())
        {
            if (entry.Annotation is null || entry.Gua is null)
                continue;
            yield return (entry.Gua, entry.Annotation);
        }
    }
}
