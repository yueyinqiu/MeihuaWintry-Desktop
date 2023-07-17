using System.Diagnostics.CodeAnalysis;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class StoredGua : IStoredGua
{
    private string name;
    public required string Name
    {
        get => this.name;
        [MemberNotNull(nameof(name))]
        set => this.name = value ?? "";
    }

    private Gua gua;
    public required Gua Gua
    {
        get => this.gua;
        [MemberNotNull(nameof(gua))]
        set => this.gua = value ?? new Gua();
    }

    public required string? AnnotationKey { get; set; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Gua} ({this.AnnotationKey})";
    }

    public static StoredGua FromInterfaceType(IStoredGua g)
    {
        return new StoredGua() {
            Name = g.Name,
            Gua = g.Gua,
            AnnotationKey = g.AnnotationKey
        };
    }
}
