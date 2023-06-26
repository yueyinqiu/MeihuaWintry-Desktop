using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MeihuaWintryDesktop.Entities;
using MeihuaWintryDesktop.Tools;

namespace MeihuaWintryDesktop.Controls;

public partial class CaseDisplayControl : UserControl
{
    public CaseDisplayControl()
    {
        InitializeComponent();
    }

    public string? CurrentCasePath { get; private set; }
    public StoredCase? CurrentCase { get; private set; }
    public void SetCase(StoredCase c, string? path)
    {
        CurrentCase = c;
        CurrentCasePath = path;
        this.IsSaved = path is not null;
    }

    public bool IsSaved { get; private set; } = true;
    public void SetSaved()
    {
        IsSaved = true;
    }
}
