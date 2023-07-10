using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredCaseWithId : IStoredCase
{
    ObjectId? CaseId { get; }
}
