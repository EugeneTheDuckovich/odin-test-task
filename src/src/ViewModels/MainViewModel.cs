using System.Windows.Input;
using src.Services.Abstract;
using src.Utilities;

namespace src.ViewModels;

public class MainViewModel : NotifyPropertyChanged
{
    private readonly IFormatNameService _formatNameService;

    private string _input;
    private string _output;

    public string Input
    {
        get => _input;
        set
        {
            _input = value;
            OnPropertyChanged(nameof(Input));
        }
    }

    public string Output
    {
        get => _output;
        set
        {
            _output = value;
            OnPropertyChanged(nameof(Output));
        }
    }
    
    public MainViewModel(IFormatNameService formatNameService)
    {
        _formatNameService = formatNameService;
        Input = string.Empty;
        Output = string.Empty;
    }

    public ICommand FormatNameCommand => new RelayCommand(
        parameter =>
        {
            Output = _formatNameService.FormatFullName(Input);
        });
}