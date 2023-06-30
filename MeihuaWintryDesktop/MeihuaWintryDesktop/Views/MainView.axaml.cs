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

        this.Closing += async (_, e) => {
            if (isCloseRequired)
                return;
            
            e.Cancel = true;
            if (await this.CheckSavedAndConfirmContinuing())
            {
                isCloseRequired = true;
                this.Close();
            }
        };
    }

    private async Task<bool> CheckSavedAndConfirmContinuing()
    {
        return true;

        /*
        if (caseDisplayControl.IsSaved)
            return true;

        var window = new MessageWindow();
        return await window.ShowDialog(
            this, "占例未保存", "当前占例还没有保存，确定要继续么？", "继续", "取消");
        */
    }
}
