using Avalonia.Controls;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop;

public partial class MessageWindow : Window
{
    public MessageWindow()
    {
        this.InitializeComponent();

        this.buttonYes.Click += (_, _) => this.Close(true);
        this.buttonNo.Click += (_, _) => this.Close(false);
    }

    public Task ShowDialog(
        Window owner, string title, string message, string yesText)
    {
        this.Title = title;
        this.textBoxMessage.Text = message;
        this.buttonYes.Content = yesText;
        this.buttonNo.IsVisible = false;

        return this.ShowDialog(owner);
    }

    public Task<bool> ShowDialog(
        Window owner, string title, string message, string yesText, string noText)
    {
        this.Title = title;
        this.textBoxMessage.Text = message;
        this.buttonYes.Content = yesText;
        this.buttonNo.Content = noText;
        this.buttonNo.IsVisible = true;

        return this.ShowDialog<bool>(owner);
    }
}
