using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring.AccessHistorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;
public sealed class AccessHistory : IStoredAccessHistory
{
    internal AccessHistory(IStoredAccessHistory history)
    {
        this.File = history.File;
        this.LastAccess = history.LastAccess;
        this.IsTrusted = history.IsTrusted;
    }

    public FileInfo File { get; internal set; }
    public DateTime LastAccess { get; internal set; }
    public bool IsTrusted { get; internal set; }
}
