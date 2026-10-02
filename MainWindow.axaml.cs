using System;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Avalonia.Controls.Shapes;

namespace GA;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.Content = "Bugger Off";
        Console.WriteLine($"The sender is {button.Name}");

        var process = new Process();    
        process.StartInfo.FileName = "ssh"; 
        process.StartInfo.ArgumentList.Add("piuser@192.168.0.110");
        process.StartInfo.ArgumentList.Add("loginctl --no-legend");
        process.StartInfo.RedirectStandardOutput = true;   
        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        //Console.WriteLine(output);
        var lines = output.Split("\n");

    
        foreach(var line in lines) {
            if (line == "") {continue;};
            //Console.WriteLine($"lekker kernel {line}");
            var fields = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
                // if ((fields[3] == "seat0") &&
                //     (fields[5] == "user") &&
                //     (fields[6] == "tty2"))
                // {
                //     Console.Write($"Die een --->>> {line} ");
                // } else
                // {
                //     Console.Write($"Nie die een nie --->>> {line} ");  
                // }
            
        } 
     
        //Terminal terminal = new Terminal();
        

    
    }
}