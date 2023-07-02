using LiteDB;
using System.Linq.Expressions;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
public interface ICaseManager
{
    IEnumerable<IStoredCaseWithId> CasesInOrder<TKey>(
        Expression<Func<IStoredCase, TKey>> keySelector, bool byDescending = false);
}
