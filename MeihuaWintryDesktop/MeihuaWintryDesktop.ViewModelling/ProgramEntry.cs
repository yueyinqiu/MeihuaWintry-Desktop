using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Popups;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using MeihuaWintryDesktop.ViewModelling.Tools.ParameterizedStarting;

namespace MeihuaWintryDesktop.ViewModelling;
public sealed class ProgramEntry : IDisposable
{
    public MainViewModel MainViewModel { get; }

    public DisposableManager DisposableManager { get; }
    public void Dispose()
    {
        this.DisposableManager.Dispose();
    }

    public ProgramEntry(StartingArguments arguments)
    {
        this.DisposableManager = new DisposableManager();

        GlobalConfiguration configuration;
        try
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.GetFullPath("MeihuaWintry", path);
            path = Path.GetFullPath("configs.db", path);
            configuration = new GlobalConfiguration(new FileInfo(path));
            this.DisposableManager.Add(configuration);
        }
        catch (Exception e)
        {
            var message = $"在加载全局配置时发生了异常，程序将自动退出。" +
                $"如果一直遇到此问题，请联系开发者解决。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{e}";
            var popup = new MessagePopup() {
                Title = "无法加载全局配置",
                Message = message,
                YesText = "确定",
                NoText = null,
            };
            this.MainViewModel = new MainViewModel(popup);
            return;
        }

        this.MainViewModel = new MainViewModel(configuration, arguments);
    }
}
