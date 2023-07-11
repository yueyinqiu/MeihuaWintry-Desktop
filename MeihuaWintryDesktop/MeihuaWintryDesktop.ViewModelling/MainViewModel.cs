using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Editors;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Sidebars;
using System.Diagnostics.CodeAnalysis;

namespace MeihuaWintryDesktop.ViewModelling;

public sealed partial class MainViewModel : ObservableObject, IPopupViewModel, IDisposable
{
    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private bool isClosed;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IPopupViewModel? popup;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private IEditorViewModel? editor;

    // TODO: 把 setter 设为 private 。
    [ObservableProperty]
    private ISidebarViewModel? sidebar;

    private readonly GlobalConfiguration? configurations;

    private static bool PrepareGlobalConfiguration(
        [MaybeNullWhen(false)] out GlobalConfiguration result,
        [MaybeNullWhen(true)] out Exception exception)
    {
        try
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.GetFullPath("MeihuaWintry", path);
            path = Path.GetFullPath("configs.db", path);
            result = new GlobalConfiguration(new(path));
            exception = null;
            return true;
        }
        catch (Exception e)
        {
            result = null;
            exception = e;
            return false;
        }
    }

    public MainViewModel()
    {
        this.IsClosed = false;

        if (!PrepareGlobalConfiguration(out configurations, out var exception))
        {
            var message = $"在加载全局配置时发生了异常，程序将自动退出。" +
                $"如果一直遇到此问题，请联系开发者解决。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{exception}";
            var popup = new MessagePopup() {
                Title = "无法加载全局配置",
                Message = message,
                YesText = "确定",
                NoText = null,
            };
            popup.ChoiceMade += (_, _) => this.IsClosed = true;
            this.Popup = popup;
            return;
        }

        this.Editor = new WelcomeEditor();
        this.Sidebar = new HistorySidebar(this, configurations);
    }

    [RelayCommand]
    private void RequestClose()
    {
        // 如果要在关闭前做一些操作，可以在这里添加。
        this.IsClosed = true;
    }

    public void Dispose()
    {
        configurations?.Dispose();
    }
}
