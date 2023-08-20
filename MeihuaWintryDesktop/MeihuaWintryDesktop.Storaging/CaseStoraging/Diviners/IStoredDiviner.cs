using LiteDB;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
public interface IStoredDiviner
{
    string PreScript { get; }
    string DefaultScript { get; }
    string PostScript { get; }
}
