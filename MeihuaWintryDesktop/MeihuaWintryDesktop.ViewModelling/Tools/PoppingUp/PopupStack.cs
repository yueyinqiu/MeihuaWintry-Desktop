using MeihuaWintryDesktop.ViewModelling.Popups;

namespace MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;
public sealed class PopupStack
{
    private readonly LinkedList<IPopupViewModel> popups = new();
    private readonly IPopupContext context;
    
    internal PopupStack(IPopupContext context)
    {
        this.context = context;
    }

    public void Popup(IPopupViewModel popup)
    {
        var current = context.Popup;
        if (current is not null)
            popups.AddFirst(current);
        context.Popup = popup;
    }

    public bool Close(IPopupViewModel? popup)
    {
        if (popup is null)
            return false;

        if (context.Popup == popup)
        {
            var next = popups.First?.Value;
            context.Popup = next;
            if (next is not null)
                popups.RemoveFirst();
            return true;
        }
        else
        {
            return popups.Remove(popup);
        }
    }
}
