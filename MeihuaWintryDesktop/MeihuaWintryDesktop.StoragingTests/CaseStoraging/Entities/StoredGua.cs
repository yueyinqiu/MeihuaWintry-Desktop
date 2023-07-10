using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.StoragingTests.CaseStoraging.Entities;
internal class StoredGua : IStoredGua
{
    public string Name { get; set; }

    public Gua Gua { get; set; }

    public Gua Display { get; set; }
}
