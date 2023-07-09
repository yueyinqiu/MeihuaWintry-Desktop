using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
public interface IDivinerManager
{
    string CustomDivinerCode { get; set; }

    byte[] GetReference(ObjectId id);
    ObjectId AddReference(byte[] bytes);
    void RemoveReference(ObjectId id);
    IEnumerable<ObjectId> EnumerateReferences();
}
