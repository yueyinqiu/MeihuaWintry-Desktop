using Avalonia.Controls;
using MeihuaWintryDesktop.Views.ViewLocating;
using MeihuaWintryDesktop.ViewModels;
using System;

namespace MeihuaWintryDesktop.Views;

public sealed partial class WelcomePageView : UserControl, ILocatableView
{
    public static Type TypeOfViewModel => typeof(WelcomePageViewModel);

    public WelcomePageView()
    {
        InitializeComponent();
    }
}
