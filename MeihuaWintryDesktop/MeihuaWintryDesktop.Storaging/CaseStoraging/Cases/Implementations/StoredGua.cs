using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class StoredGua : IStoredGua
{
    public required string? Name { get; set; }
    string IStoredGua.Name => this.Name ?? "";

    public required Gua? Gua { get; set; }
    Gua IStoredGua.Gua => this.Gua ?? new Gua();

    public required Gua? Display { get; set; }
    Gua IStoredGua.Display => this.Display ?? new Gua();

    public override string ToString()
    {
        return $"{this.Name}: {this.Display} ({this.Gua})";
    }

    public static StoredGua FromInterfaceType(IStoredGua g)
    {
        return new StoredGua() {
            Name = g.Name,
            Gua = g.Gua,
            Display = g.Display
        };
    }
}
