using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class NamedGua : INamed<Gua>
{
    public required string? Name { get; set; }
    string INamed<Gua>.Name => this.Name ?? "";

    public required Gua? Value { get; set; }
    Gua INamed<Gua>.Value => this.Value ?? new Gua();

    public override string ToString()
    {
        return $"{this.Name}: {this.Value}";
    }

    public static NamedGua FromInterfaceType(INamed<Gua> g)
    {
        return new NamedGua() {
            Name = g.Name,
            Value = g.Value
        };
    }
}
