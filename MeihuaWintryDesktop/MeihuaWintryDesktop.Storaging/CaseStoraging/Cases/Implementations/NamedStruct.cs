using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class NamedStruct<T> : INamed<T> where T : struct
{
    public string? Name { get; set; }
    string INamed<T>.Name => this.Name ?? "";

    public T Value { get; set; }
}
