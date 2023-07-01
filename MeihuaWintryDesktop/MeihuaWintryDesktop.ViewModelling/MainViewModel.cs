using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IPopupViewModel
{
    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool isClosed = false;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IPopupViewModel? popup = null;

    public ObservableCollection<IEditorViewModel> Editors { get; } = new() {
        new WelcomeViewModel()
    };

    [RelayCommand]
    private void RequestClose()
    {
        if (!this.Editors.Any(e => e.IsNotSaved))
        {
            this.IsClosed = true;
            return;
        }

        var popup = new MessagePopupViewModel(
            "确定要退出么？",
            "您当前编辑的内容可能还未保存。确定要退出么？", "确定", "取消");
        popup.Choosed += (sender, e) => {
            if (this.Popup == sender)
                this.Popup = null;
            if (e.IsYes)
                this.IsClosed = true;
        };
        this.Popup = popup;
    }

    [RelayCommand]
    private void RequestEditorClose(IEditorViewModel editorViewModel)
    {
        if (!this.Editors.Any(e => e.IsNotSaved))
        {
            this.IsClosed = true;
            return;
        }

        var popup = new MessagePopupViewModel(
            "确定要退出么？",
            "您当前编辑的内容可能还未保存。确定要退出么？", "确定", "取消");
        popup.Choosed += (sender, e) => {
            if (this.Popup == sender)
                this.Popup = null;
            if (e.IsYes)
                this.IsClosed = true;
        };
        this.Popup = popup;
    }
}
