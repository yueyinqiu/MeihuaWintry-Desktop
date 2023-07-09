namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;

public interface IStoredGregorianTime
{
    int? Year { get; }

    int? Month { get; }

    int? Day { get; }

    int? Hour { get; }

    int? Minute { get; }
}
