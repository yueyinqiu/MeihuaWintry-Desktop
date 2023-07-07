﻿using MeihuaWintryDesktop.ViewModelling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MeihuaWintryDesktopWpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        this.MainWindow = new MainWindow() {
            DataContext = new MainViewModel()
        };
        this.MainWindow.Show();
    }
}