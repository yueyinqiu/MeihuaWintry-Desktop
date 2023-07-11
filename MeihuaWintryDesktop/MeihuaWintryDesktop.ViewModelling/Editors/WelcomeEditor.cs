using CommunityToolkit.Mvvm.ComponentModel;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class WelcomeEditor : ObservableObject, IEditorViewModel
{
    internal WelcomeEditor()
    {

    }
    public string Title => "欢迎使用冬日梅花";
    public string Description => "冬日梅花是一款梅花易数起卦记卦软件。现在，您可以在左侧选择打开或者创建占例仓库。";
}
