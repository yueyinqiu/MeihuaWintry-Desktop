using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;

namespace MeihuaWintryDesktop.ViewModelling.Sidebars;

public abstract partial class SidebarBase : ObservableObject, ISidebarViewModel
{
    protected MainViewModel MainViewModel { get; }

    protected abstract CaseStore? GetStoreIfExists();

    internal SidebarBase(MainViewModel mainViewModel)
    {
        this.MainViewModel = mainViewModel;
    }

    [RelayCommand]
    private void OpenCaseFile()
    {
        void DoOpenCase(string path)
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

            this.GetStoreIfExists()?.Dispose();
            this.MainViewModel.Sidebar = new StoreSidebar(this.MainViewModel, store);
            this.MainViewModel.Editor = new StoreInformationEditor(store);
        }

        var popup = new FileSelectionPopup("请选择要打开的占例文件");
        popup.ChoiceMade += (_, e) => {
            this.MainViewModel.Popup = null;
            if (e.IsCancelled)
                return;
            DoOpenCase(e.EnteredPath);
        };
        this.MainViewModel.Popup = popup;
    }
}
