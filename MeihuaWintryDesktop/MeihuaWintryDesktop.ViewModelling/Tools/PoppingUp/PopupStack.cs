using MeihuaWintryDesktop.ViewModelling.Popups;

namespace MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;
internal sealed class PopupStack
{
    private readonly LinkedList<IPopupViewModel> popups = new();
    private readonly IPopupContext context;

    internal PopupStack(IPopupContext context)
    {
        this.context = context;
    }

    public void Popup(IPopupViewModel popup)
    {
        var current = this.context.Popup;
        if (current is not null)
            this.popups.AddFirst(current);
        this.context.Popup = popup;
    }

    public bool Close(IPopupViewModel? popup)
    {
        if (popup is null)
            return false;

        if (this.context.Popup == popup)
        {
            var next = this.popups.First?.Value;
            this.context.Popup = next;
            if (next is not null)
                this.popups.RemoveFirst();
            return true;
        }
        else
        {
            return this.popups.Remove(popup);
        }
    }
}
