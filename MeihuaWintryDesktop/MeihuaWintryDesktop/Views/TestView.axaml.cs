using Avalonia.Controls;
using MeihuaWintryDesktop.Tools.ViewLocating;
using MeihuaWintryDesktop.ViewModels;
using System;

namespace MeihuaWintryDesktop.Views;

public sealed partial class TestView : UserControl, ILocatableView
{
    public static Type TypeOfViewModel => typeof(TestViewModel);

    public TestView()
    {
        InitializeComponent();
    }
}
