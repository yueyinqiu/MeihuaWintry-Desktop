using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.Entities;
public sealed class StoredCase
{
    [JsonConstructor]
    public StoredCase(string? name)
    {
        this.Name = name ?? "无名称占例";
    }

    public string Name { get; }
}
