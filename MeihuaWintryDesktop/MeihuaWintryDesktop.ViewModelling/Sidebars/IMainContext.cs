using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;
public interface IMainContext
{
    internal ISidebarViewModel? Sidebar { get; set; }

    internal IEditorViewModel? Editor { get; set; }

    internal PopupStack PopupStack { get; }
}
