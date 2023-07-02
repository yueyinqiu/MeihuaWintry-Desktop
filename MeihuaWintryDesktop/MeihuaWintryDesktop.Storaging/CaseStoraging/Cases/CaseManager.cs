using LiteDB;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Entities.Implementations;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
public sealed class CaseManager
{
    private readonly ILiteCollection<StoredCase> collection;
    internal CaseManager(LiteDatabase database)
    {
        database.Mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Tiangan.Parse(b.AsString));
        database.Mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Dizhi.Parse(b.AsString));
        database.Mapper.RegisterType(
            (x) => x.ToString(),
            (b) => Gua.Parse(b.AsString));

        var collection = database.GetCollection<StoredCase>();
        this.collection = collection;
    }
}
