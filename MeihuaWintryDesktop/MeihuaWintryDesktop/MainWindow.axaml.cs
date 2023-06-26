using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Dialogs;
using System;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        this.menuItemNewCase.Click += async (_, _) => await NewCase();
        this.menuItemOpenCase.Click += async (_, _) => await OpenCase();
        this.menuItemSaveCase.Click += (_, _) => SaveCase();
        this.menuItemOpenCase.Click += (_, _) => SaveCaseAs();
        this.menuItemExitProgram.Click += (_, _) => this.Close();

        this.Closing += async (_, e) => {
            if (!await CheckSavedAndConfirmContinuing())
                e.Cancel = true;
        };
    }

    private async Task<bool> CheckSavedAndConfirmContinuing()
    {
        if (caseDisplayControl.IsSaved)
            return true;

        var window = new MessageWindow();
        return await window.ShowDialog(
            this, "占例未保存", "当前占例还没有保存，确定要继续么？", "继续", "取消");
    }
    
    public async Task NewCase()
    {
        if (!await CheckSavedAndConfirmContinuing())
            return;

        this.caseDisplayControl.SetCase(new($"{DateTime.Now}"), null);
    }

    public async Task OpenCase()
    {
        if (!await CheckSavedAndConfirmContinuing())
            return;

    }

    public void SaveCase()
    {

    }

    public void SelectSavePosition()
    {

    }

    public void SaveCaseAs()
    {

    }
}
