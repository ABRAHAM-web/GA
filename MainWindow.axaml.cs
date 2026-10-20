using System;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Avalonia.Controls.Shapes;
using System.Security.Cryptography;
using Tmds.DBus.Protocol;
using Avalonia.Remote.Protocol.Viewport;

namespace GA;

public partial class MainWindow : Window
{
    private TerminalManager _terminalManager;
    private bool _configLoaded;
    public bool ConfigLoaded => _configLoaded;
    public MainWindow(TerminalManager terminalManager, bool configLoaded)
    {
        InitializeComponent();
        _terminalManager = terminalManager;
        DataContext = _terminalManager;
        _configLoaded = configLoaded;

        TerminalList.IsVisible = _configLoaded;
        ConfigErrorPanel.IsVisible = !_configLoaded;
        
    }

    private bool UpdateTerminalRuntime(Terminal terminal)
    {
        var process = new Process();

        process.StartInfo.FileName = "ssh";

        process.StartInfo.ArgumentList.Add(
            $"piuser@{terminal.TerminalIpAddress}");

        process.StartInfo.ArgumentList.Add("loginctl --no-legend");

        process.StartInfo.RedirectStandardOutput = true;

        process.StartInfo.RedirectStandardError = true;

        process.Start();

        var output = process.StandardOutput.ReadToEnd();

        var lines = output.Split('\n');

        process.WaitForExit();

        int exitCode = process.ExitCode;

        if (exitCode !=0)
        {
            return false;
        }     

        foreach (var line in lines)
        {
            var fields = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length < 7)
            {
                if (fields[2] == "piuser" &&
                fields[3] == "seat0" &&
                fields[5] == "user" &&
                fields[6] == "tty2")
                {
                    Console.WriteLine($"On Terminal {terminal.TerminalName} the active session is {fields[0]} ");
                    terminal.SessionId = fields[0];

                    var detailProcess = new Process();
                    detailProcess.StartInfo.FileName = "ssh";

                    detailProcess.StartInfo.ArgumentList.Add(
                        $"piuser@{terminal.TerminalIpAddress}");

                    detailProcess.StartInfo.ArgumentList.Add(
                        $"loginctl show-session {terminal.SessionId}");

                    detailProcess.StartInfo.RedirectStandardOutput = true;

                    detailProcess.StartInfo.RedirectStandardError = true;

                    detailProcess.Start();   

                    var detailOutput = detailProcess.StandardOutput.ReadToEnd();
                    var detailLines = detailOutput.Split('\n');

                    foreach (var detailLine in detailLines)
                    {                       
                       var parts = detailLine.Split('=',2);
                       if (parts.Length !=2)
                        {
                            continue;
                        }
                        var key = parts[0].Trim();
                        var val = parts[1].Trim();

                        if (key == "Id") terminal.SessionId = val;
                        else if (key == "User") terminal.User = val;
                        else if (key == "Seat") terminal.Seat = val;
                        else if (key == "Type") terminal.Type = val;
                        else if (key == "Class") terminal.Class = val;
                        else if (key == "Type") terminal.Type = val;
                        else if (key == "Active") terminal.Active = val == "yes";


                    }

                    //return true;
                }
            }
        }

        return false;
    }

    private void RefreshButton_Click(object? sender, RoutedEventArgs e)
    {
        //Console.WriteLine("Refresh button clicked!");
        //Console.WriteLine($"Process path: {Environment.ProcessPath}");
        var startInfo = new ProcessStartInfo
    {
        FileName = Environment.ProcessPath!,
        UseShellExecute = false
    };

    Process.Start(startInfo);

    Close();
    }
    //private void StartButton_Click(object? sender, RoutedEventArgs e)
    //{
        //  var button = (Button)sender;
        //  button.Content = "Bugger Off";
        //  Console.WriteLine($"The sender is {button.Name}");

        // var process = new Process();    
        // process.StartInfo.FileName = "ssh"; 
        // process.StartInfo.ArgumentList.Add("piuser@192.168.0.110");
        // process.StartInfo.ArgumentList.Add("loginctl --no-legend");
        // process.StartInfo.RedirectStandardOutput = true;   
        // process.Start();
        // var output = process.StandardOutput.ReadToEnd();
        // Console.WriteLine(output);
        // var lines = output.Split("\n");

    
        // foreach(var line in lines) {
        //     if (line == "") {continue;};
        //     Console.WriteLine($"lekker kernel {line}");
        //     var fields = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
        //         if ((fields[3] == "seat0") &&
        //             (fields[5] == "user") &&
        //             (fields[6] == "tty2"))
        //         {
        //             Console.Write($"Die een --->>> {line} ");
        //         } else
        //         {
        //             Console.Write($"Nie die een nie --->>> {line} ");  
        //         }
            
        // } 
     
        //Terminal terminal = new Terminal();
        

    
    }
//}