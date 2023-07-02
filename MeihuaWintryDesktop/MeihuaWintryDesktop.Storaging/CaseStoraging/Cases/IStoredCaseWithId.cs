using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredCaseWithId : IStoredCase
{
    ObjectId CaseId { get; }
}
