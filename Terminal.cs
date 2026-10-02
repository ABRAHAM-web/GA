namespace GA;

public class Terminal
{
    // Configuration — comes from terminals.json
    public string TerminalId { get; set; } = string.Empty;
    public string TerminalName { get; set; } = string.Empty;
    public string TerminalIpAddress { get; set; } = string.Empty;
    public string TerminalNumber { get; set; } = string.Empty;

    // Runtime state — discovered from the terminal
    public string SessionId { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public bool Active { get; set; }
    public bool Locked { get; set; }
}