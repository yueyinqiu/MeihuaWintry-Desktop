using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
public interface IStoredGua
{
    string Name { get; }
    Gua Gua { get; }
    Gua Display { get; }
}
