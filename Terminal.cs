namespace GA;
using System.Text.Json.Serialization;
using System.ComponentModel;

public class Terminal : INotifyPropertyChanged
{
    // Configuration — comes from terminals.json
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _terminalId  = string.Empty;
    public string TerminalId
    {
        get => _terminalId;

        set
        {
            if (_terminalId == value)
                return;

            _terminalId = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(TerminalId)));
        }
    }
    public string _terminalName { get; set; } = string.Empty;
    public string TerminalName
    {
        get => _terminalName;

        set
        {
            if (_terminalName == value)
                return;

            _terminalName = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(TerminalName)));
        }
    }
    
    public string _terminalIpAddress = string.Empty;
    public string TerminalIpAddress
    {
        get => _terminalIpAddress;

        set
        {
            if (_terminalIpAddress == value)
                return;

            _terminalIpAddress = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(TerminalIpAddress)));
        }
    }
    public string _terminalNumber = string.Empty;
    public string TerminalNumber
    {
        get => _terminalNumber;

        set
        {
            if (_terminalNumber == value)
                return;

            _terminalNumber = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(TerminalNumber)));
        }
    }
    

    // public bool MonitoringEnabled { get; set; }

    private bool _monitoringEnabled = false;

    public bool MonitoringEnabled
    {
        get => _monitoringEnabled;

        set
        {
            if (_monitoringEnabled == value)
                return;

            _monitoringEnabled = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(MonitoringEnabled)));
        }
    }

    // Runtime state — discovered from the terminal
    [JsonIgnore]
    public string SessionId { get; set; } = string.Empty;
    [JsonIgnore]
    public string User { get; set; } = string.Empty;
    [JsonIgnore]
    public string Seat { get; set; } = string.Empty;
    [JsonIgnore]
    public string Type { get; set; } = string.Empty;
    [JsonIgnore]
    public string Class { get; set; } = string.Empty;
    [JsonIgnore]
    public bool Active { get; set; }
    [JsonIgnore]
    public bool Locked { get; set; }
    //[JsonIgnore]
    private bool _isOn = false;

    [JsonIgnore]
    public bool IsOn
    {
        get => _isOn;
        set
        {
            if (_isOn == value)
                return;

            _isOn = value;

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(IsOn)));
        }
    }
}