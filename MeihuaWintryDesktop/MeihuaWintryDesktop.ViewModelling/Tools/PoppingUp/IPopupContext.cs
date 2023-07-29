using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.ViewModelling.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;
internal interface IPopupContext
{
    internal IPopupViewModel? Popup { get; set; }
}
