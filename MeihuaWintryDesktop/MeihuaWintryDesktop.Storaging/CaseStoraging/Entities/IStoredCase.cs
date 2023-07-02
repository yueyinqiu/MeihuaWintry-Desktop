using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Entities;

public interface IStoredCase
{
    string Title { get; }

    string Owner { get; }
    string OwnerDescription { get; }

    IGregorianTime GregorianTime { get; }
    IChineseSolarTime ChineseSolarTime { get; }
    IChineseLunarTime ChineseLunarTime { get; }

    IEnumerable<INamed<int>> Numbers { get; }
    IEnumerable<INamed<Gua>> Guas { get; }

    string Notes { get; }
    IEnumerable<string> Tags { get; }
}
