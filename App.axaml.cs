using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GA;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            
            TerminalManager terminalManager = new TerminalManager();

            bool configLoaded = terminalManager.Load();

            if (configLoaded)
            {
                Console.WriteLine("The terminal could be loaded");
                Console.WriteLine($"Terminal 1: {terminalManager.Terminals[0].TerminalName}");
                Console.WriteLine($"Terminal 1 IP: {terminalManager.Terminals[0].TerminalIpAddress}");
                Console.WriteLine($"Number of terminals: {terminalManager.Terminals.Count}");
            } else
            {
                Console.Write("The terminals could not be loaded");
            }

            



            desktop.MainWindow = new MainWindow(terminalManager,configLoaded);
        } 

            base.OnFrameworkInitializationCompleted();
    }
}