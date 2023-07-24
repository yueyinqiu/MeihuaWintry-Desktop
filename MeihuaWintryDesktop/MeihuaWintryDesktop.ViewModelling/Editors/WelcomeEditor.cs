using CommunityToolkit.Mvvm.ComponentModel;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class WelcomeEditor : ObservableObject, IEditorViewModel
{
    internal WelcomeEditor()
    {

    }
    public string Messages => 
        $"欢迎使用冬日梅花。{Environment.NewLine}" +
        $"冬日梅花是一款梅花易数起卦记卦软件。{Environment.NewLine}" +
        $"您可以在左侧选择打开或者创建一个占例仓库开始使用。";
}
