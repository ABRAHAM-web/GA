using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.ComponentModel;

namespace GA;

public class TerminalManager
{
    private List<Terminal> _terminals = new List<Terminal>();

    public List<Terminal> Terminals
    {
        get { return _terminals; }
    }

    public void Load()
    {
        string json = File.ReadAllText("terminals.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        _terminals = JsonSerializer.Deserialize<List<Terminal>>(json, options)
                     ?? new List<Terminal>();

        foreach (Terminal terminal in _terminals)
        {
            terminal.PropertyChanged += Terminal_PropertyChanged;
        }
    }
    

    public void Save()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_terminals, options);

        File.WriteAllText("terminals.json", json);
    }


    
    private void Terminal_PropertyChanged(
    object? sender,
    PropertyChangedEventArgs e)
    {        
        switch (e.PropertyName)
        {
            case nameof(Terminal.TerminalId):
            case nameof(Terminal.TerminalName):
            case nameof(Terminal.TerminalIpAddress):
            case nameof(Terminal.TerminalNumber):
            case nameof(Terminal.MonitoringEnabled):
                Console.WriteLine(
                    $"Configuration changed: {e.PropertyName}");
                break;
            
        }
        Save();
    }
}