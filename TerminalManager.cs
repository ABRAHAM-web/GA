using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
    }
}