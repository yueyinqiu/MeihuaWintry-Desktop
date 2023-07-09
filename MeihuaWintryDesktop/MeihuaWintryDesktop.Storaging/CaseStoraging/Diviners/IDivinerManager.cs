using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
public interface IDivinerManager
{
    string DivinerScript { get; set; }

    ObjectId AddReference(byte[] content);
    void RemoveReference(ObjectId id);
    IEnumerable<(ObjectId id, byte[] content)> EnumerateReferences();
    IEnumerable<ObjectId> EnumerateReferenceIds();
}
