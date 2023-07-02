using LiteDB;
using System;
using System.Linq.Expressions;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
public sealed class CaseManager : ICaseManager
{
    private readonly BsonMapper mapper;
    private readonly ILiteCollection<StoredCase> collection;
    internal CaseManager(LiteDatabase database)
    {
        this.mapper = database.Mapper;
        mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Tiangan.Parse(b.AsString));
        mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Dizhi.Parse(b.AsString));
        mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Gua.Parse(b.AsString));

        var collection = database.GetCollection<StoredCase>();
        this.collection = collection;
    }

    public IEnumerable<IStoredCaseWithId> CasesInOrder<TKey>(
        Expression<Func<IStoredCase, TKey>> keySelector, bool byDescending = false)
    {
        var query = collection.Query();
        var bsonKeySelector = mapper.GetExpression(keySelector);

        if (byDescending)
            query = query.OrderByDescending(bsonKeySelector);
        else
            query = query.OrderBy(bsonKeySelector);
        return query.ToEnumerable();
    }
}
