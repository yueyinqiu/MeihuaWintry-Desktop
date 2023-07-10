using System.Diagnostics.CodeAnalysis;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class StoredNumber : IStoredNumber
{
    private string name;
    public required string Name
    {
        get => this.name;
        [MemberNotNull(nameof(name))]
        set => this.name = value ?? "";
    }

    public required int Number { get; set; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Number}";
    }

    public static StoredNumber FromInterfaceType(IStoredNumber n)
    {
        return new StoredNumber() {
            Name = n.Name,
            Number = n.Number
        };
    }
}
