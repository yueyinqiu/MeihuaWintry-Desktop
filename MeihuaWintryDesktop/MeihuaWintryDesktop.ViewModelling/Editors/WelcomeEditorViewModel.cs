using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MeihuaWintryDesktop.ViewModelling.Editors;

public sealed partial class WelcomeEditorViewModel : ObservableObject, IEditorViewModel
{
    internal WelcomeEditorViewModel()
    {

    }
    public string Title => "欢迎使用冬日梅花";
    public string Description => "冬日梅花是一款梅花易数起卦记卦软件。现在，您可以在左侧选择打开或者创建占例仓库。";
}
