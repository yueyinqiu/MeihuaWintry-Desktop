using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Annotations.Implementations;
public sealed class AnnotationManager : IAnnotationManager
{
    private readonly ILiteCollection<StoredAnnotationEntry> collection;
    internal AnnotationManager(LiteDatabase database)
    {
        database.Mapper.RegisterType<Gua>(
            (x) => x.ToBytes(),
            (b) => Gua.FromBytes(b));

        this.collection = database.GetCollection<StoredAnnotationEntry>(CollectionNames.Annotations);
    }

    public string? this[Gua gua]
    {
        get
        {
            var result = this.collection.FindOne(x => x.Gua == gua);
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
                Annotation = value,
                EntryId = x.EntryId,
                Gua = x.Gua
            }, x => x.Gua == gua);
            if (updateResult is 0)
            {
                this.collection.Insert(new StoredAnnotationEntry() {
                    Annotation = value,
                    EntryId = null,
                    Gua = gua
                });
            }
        }
    }

    public IEnumerable<(Gua gua, string annotation)> Enumerate()
    {
        foreach (var entry in this.collection.FindAll())
        {
            if (entry.Annotation is null)
                continue;
            yield return (entry.Gua ?? new Gua(), entry.Annotation);
        }
    }
}
