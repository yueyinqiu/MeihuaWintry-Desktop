using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Popups;
public abstract class PopupBase : ObservableObject, IPopupViewModel
{
    private readonly PopupStack? popupStack;
    private protected PopupBase(PopupStack? autoClose)
    {
        this.popupStack = autoClose;
    }

    protected void TryAutoClose()
    {
        this.popupStack?.Close(this);
    }
}
