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
    public string? Name { get; set; }
    string INamed<Gua>.Name => this.Name ?? "";

    public Gua? Value { get; set; }
    Gua INamed<Gua>.Value => this.Value ?? new Gua();
}
