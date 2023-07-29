using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Popups.FileSelection;
using MeihuaWintryDesktop.ViewModelling.Popups.Message;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public abstract partial class SidebarBase : ObservableObject, ISidebarViewModel
{
    protected IMainContext Context { get; }
    protected DisposableManager DisposableManager { get; }
    protected abstract CaseStore? GetStoreIfExists();

    internal SidebarBase(IMainContext context, DisposableManager disposableManager)
    {
        this.Context = context;
        this.DisposableManager = disposableManager;
    }

    [RelayCommand]
    private void OpenStore()
    {
        var popup = new FileSelectionPopup() {
            Title = "请选择要打开的占例文件",
            AutoClose = this.Context.PopupStack
        };
        popup.ChoiceMade += (_, e) => {
            if (e.IsCancelled)
                return;
            this.OpenStoreOrShowPopup(e.EnteredPath);
        };
        this.Context.PopupStack.Popup(popup);
    }

    internal void OpenStoreOrShowPopup(string path)
    {
        FileInfo fileInfo;
        try
        {
            fileInfo = new FileInfo(path);
        }
        catch (Exception ex)
        {
            var popupMessage = $"在尝试打开占例仓库文件时遇到了异常。" +
                $"{Environment.NewLine}这可能是因为路径本身格式不正确，或者权限不足导致的。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{ex}";
            this.Context.PopupStack.Popup(new MessagePopup() {
                Title = "无法打开占例仓库",
                Message = popupMessage,
                YesText = "确定",
                NoText = null,
                AutoClose = this.Context.PopupStack
            });
            return;
        }
        CaseStore store;
        try
        {
            store = new CaseStore(fileInfo);
        }
        catch (Exception ex)
        {
            var popupMessage = $"在尝试打开占例仓库文件时遇到了异常。" +
                $"{Environment.NewLine}这可能是因为文件不存在、内容不正确，或者权限不足导致的。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{ex}";
            this.Context.PopupStack.Popup(new MessagePopup() {
                Title = "无法打开占例仓库",
                Message = popupMessage,
                YesText = "确定",
                NoText = null,
                AutoClose = this.Context.PopupStack
            });
            return;
        }
        this.DisposableManager.Add(store);
        this.DisposableManager.DisposeAndRemove(this.GetStoreIfExists());
        this.Context.Sidebar = new StoreSidebar(this.Context, this.DisposableManager, store);
        this.Context.Editor = new StoreInformationEditor(store);
    }
}
