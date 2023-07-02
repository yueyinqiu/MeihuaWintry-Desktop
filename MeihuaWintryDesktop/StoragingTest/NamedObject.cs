using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YiJingFramework.PrimitiveTypes;

namespace StoragingTest;
internal sealed class NamedObject
{
    public string? Name { get; set; }
    public object? Value { get; set; }
}
