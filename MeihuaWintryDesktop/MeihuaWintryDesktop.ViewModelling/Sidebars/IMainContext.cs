using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;
internal interface IMainContext
{
    ISidebarViewModel? Sidebar { get; set; }

    IEditorViewModel? Editor { get; set; }

    PopupStack PopupStack { get; }
}
