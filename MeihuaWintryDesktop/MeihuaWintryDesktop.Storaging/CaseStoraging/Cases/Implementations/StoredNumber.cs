using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YiJingFramework.PrimitiveTypes;

namespace MeihuaWintryDesktop.Storaging.CaseStoraging.Cases.Implementations;
internal sealed class StoredNumber : IStoredNumber
{
    public required string? Name { get; set; }
    string IStoredNumber.Name => this.Name ?? "";

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
