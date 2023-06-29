using Avalonia.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop;

public partial class MainWindow : Window
{
    bool isCloseRequired = false;
    public MainWindow()
    {
        this.InitializeComponent();

        this.menuItemNewCase.Click += async (_, _) => await this.NewCase();
        this.menuItemOpenCase.Click += async (_, _) => await this.OpenCase();
        this.menuItemSaveCase.Click += (_, _) => this.SaveCase();
        this.menuItemOpenCase.Click += (_, _) => this.SaveCaseAs();
        this.menuItemExitProgram.Click += (_, _) => this.Close();

        this.Closing += async (_, e) => {
            if (!isCloseRequired)
                e.Cancel = true;
            if (await this.CheckSavedAndConfirmContinuing())
            {
                isCloseRequired = true;
                this.Close();
            }
        };
    }

    public required DirectoryInfo DataFolder { get; init; }

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
        if (!await this.CheckSavedAndConfirmContinuing())
            return;

        this.caseDisplayControl.SetCase(new($"{DateTime.Now}"), null);
    }

    public async Task OpenCase()
    {
        if (!await this.CheckSavedAndConfirmContinuing())
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
