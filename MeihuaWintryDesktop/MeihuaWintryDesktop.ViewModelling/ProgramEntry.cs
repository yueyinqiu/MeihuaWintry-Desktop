using MeihuaWintryDesktop.Storaging.GlobalConfiguring;
using MeihuaWintryDesktop.ViewModelling.Popups.Message;
using MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
using MeihuaWintryDesktop.ViewModelling.Tools.ParameterizedStarting;

namespace MeihuaWintryDesktop.ViewModelling;
public sealed class ProgramEntry : IDisposable
{
    public MainViewModel MainViewModel { get; }

    private readonly DisposableManager disposableManager;
    public void Dispose()
    {
        this.disposableManager.Dispose();
    }

    public ProgramEntry(StartingArguments arguments)
    {
        this.disposableManager = new DisposableManager();

        GlobalConfiguration configuration;
        try
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.GetFullPath("MeihuaWintry", path);
            path = Path.GetFullPath("configs.db", path);
            configuration = new GlobalConfiguration(new FileInfo(path));
            this.disposableManager.Add(configuration);
        }
        catch (Exception e)
        {
            var message = $"在加载全局配置时发生了异常，程序将自动退出。" +
                $"如果一直遇到此问题，请联系开发者解决。" +
                $"{Environment.NewLine}具体异常信息：" +
                $"{Environment.NewLine}{e}";
            var popup = new MessagePopup(null) {
                Title = "无法加载全局配置",
                Message = message,
                YesText = "确定",
                NoText = null
            };
            this.MainViewModel = new MainViewModel(popup);
            return;
        }

        this.MainViewModel = new MainViewModel(this.disposableManager, configuration, arguments);
    }
}
