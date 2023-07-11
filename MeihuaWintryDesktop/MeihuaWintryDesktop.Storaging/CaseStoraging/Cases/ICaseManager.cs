using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
public interface ICaseManager
{
    IStoredCaseWithId? GetCase(ObjectId id);
    IStoredCaseWithId InsertCase(IStoredCase c);
    void UpdateCase(IStoredCaseWithId c);
    IEnumerable<IStoredCaseWithId> ListCasesByLastEdit();
}
