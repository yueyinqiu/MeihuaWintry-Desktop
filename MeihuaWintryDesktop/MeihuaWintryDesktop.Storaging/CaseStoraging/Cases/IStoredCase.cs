using LiteDB;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredCase
{
    string Title { get; }

    string Owner { get; }
    string OwnerDescription { get; }

    IStoredGregorianTime GregorianTime { get; }
    IStoredChineseSolarTime ChineseSolarTime { get; }
    IStoredChineseLunarTime ChineseLunarTime { get; }

    IEnumerable<IStoredNumber> Numbers { get; }
    IEnumerable<IStoredGua> Guas { get; }

    string Notes { get; }
    IEnumerable<string> Tags { get; }
}
