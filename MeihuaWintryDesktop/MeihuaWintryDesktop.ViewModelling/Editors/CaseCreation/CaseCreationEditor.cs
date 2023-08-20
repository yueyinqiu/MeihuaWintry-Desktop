﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.ViewModelling.Popups.Message;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Editors.CaseCreation;

public sealed partial class CaseCreationEditor : ObservableObject, IEditorViewModel
{
    private readonly CaseStore store;

    private readonly PopupStack popupStack;

    internal CaseCreationEditor(PopupStack popupStack, CaseStore store)
    {
        this.popupStack = popupStack;
        this.store = store;
        this.time = DateTime.Now;
    }

    [ObservableProperty]
    private string title = "";

    [ObservableProperty]
    private string owner = "";

    [ObservableProperty]
    private DateTime? time = null;

    [ObservableProperty]
    private string script = "";

    [RelayCommand]
    private async Task SubmitAsync()
    {
        CancellationTokenSource tokenSource = new();

        var popup = new MessagePopup(this.popupStack) {
            Title = "正常创建占例",
            Message = "正常创建占例，请稍等……",
            YesText = null,
            NoText = "取消"
        };
        popup.ChoiceMade += (_, _) => {
            tokenSource.Cancel();
        };

        var creator = new CaseCreator(this.store);
        try
        {
            var c = await creator.CreateAndInsertAsync(
                this.Title, this.Owner, this.Time, this.Script, tokenSource.Token);
        }
        catch (Exception ex)
        {
            var popupMessage = $"在创建占例时遇到了异常。" +
                $"{Environment.NewLine}这可能是因为起卦脚本出现异常，或者仓库文件不正常导致的。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{ex}";
            this.popupStack.Popup(new MessagePopup(this.popupStack) {
                Title = "无法创建占例",
                Message = popupMessage,
                YesText = "确定",
                NoText = null
            });
            return;
        }
    }
}
