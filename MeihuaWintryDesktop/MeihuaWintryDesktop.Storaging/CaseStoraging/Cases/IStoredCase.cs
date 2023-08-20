namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredCase
{
    string Title { get; }

    string Owner { get; }
    string OwnerDescription { get; }

    DateTime? DivinationTime { get; }

    IEnumerable<IStoredNumber> Numbers { get; }
    IEnumerable<IStoredGua> Guas { get; }

    string Notes { get; }
    IEnumerable<string> Tags { get; }
}
