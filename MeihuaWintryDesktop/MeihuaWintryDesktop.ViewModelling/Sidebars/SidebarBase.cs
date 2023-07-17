using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public abstract partial class SidebarBase : ObservableObject, ISidebarViewModel
{
    protected MainViewModel MainViewModel { get; }
    protected DisposableManager DisposableManager { get; }
    protected abstract CaseStore? GetStoreIfExists();

    internal SidebarBase(MainViewModel mainViewModel, DisposableManager disposableManager)
    {
        this.MainViewModel = mainViewModel;
        this.DisposableManager = disposableManager;
    }

    [RelayCommand]
    private void OpenStore()
    {
        var popup = new FileSelectionPopup("请选择要打开的占例文件");
        popup.ChoiceMade += (_, e) => {
            this.MainViewModel.Popup = null;
            if (e.IsCancelled)
                return;
            this.OpenStoreOrShowPopup(e.EnteredPath);
        };
        this.MainViewModel.Popup = popup;
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
            this.MainViewModel.Popup = new MessagePopup() {
                Title = "无法打开占例仓库",
                Message = popupMessage,
                YesText = "确定",
                NoText = null
            };
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
            this.MainViewModel.Popup = new MessagePopup() {
                Title = "无法打开占例仓库",
                Message = popupMessage,
                YesText = "确定",
                NoText = null
            };
            return;
        }
        this.DisposableManager.Add(store);
        this.DisposableManager.DisposeAndRemove(this.GetStoreIfExists());
        this.MainViewModel.Sidebar = new StoreSidebar(this.MainViewModel, this.DisposableManager, store);
        this.MainViewModel.Editor = new StoreInformationEditor(store);
    }
}
