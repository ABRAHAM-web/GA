using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

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
    }
}