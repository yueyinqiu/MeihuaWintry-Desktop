using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.ViewModelling.Popups.Message;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
using MeihuaWintryDesktop.ViewModelling.Tools.PoppingUp;

namespace MeihuaWintryDesktop.ViewModelling.Editors.CaseCreation;

public sealed partial class CaseCreationEditor : ObservableObject, IEditorViewModel
{
    private readonly CaseStore store;
    private readonly PopupStack popupStack;
    private readonly CaseCreator caseCreator;

    internal CaseCreationEditor(PopupStack popupStack, CaseStore store)
    {
        this.popupStack = popupStack;
        this.store = store;
        this.caseCreator = new CaseCreator(this.store);

        this.Time = DateTime.Now;
        this.Title = $"新占例 {this.Time:yyyy/MM/dd HH:mm}";
        this.Owner = "";
        this.OwnerSelections = store.Cases.CreateQuery()
            .OrderByLastEdit(true)
            .Limit(100)
            .Query()
            .Select(x => x.Owner)
            .Distinct();
        this.Script = this.caseCreator.DefaultScript;
    }

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string owner;

    public IEnumerable<string> OwnerSelections { get; }

    [ObservableProperty]
    private DateTime? time;

    [ObservableProperty]
    private string script;

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

        IStoredCase createdCase;
        try
        {
            createdCase = await this.caseCreator.CreateAsync(
                this.Title, this.Owner, this.Time, this.Script, tokenSource.Token);
        }
        catch (Exception ex)
        {
            var popupMessage = $"占例创建失败。" +
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
        var storedCase = this.store.Cases.InsertCase(createdCase);
    }
}
