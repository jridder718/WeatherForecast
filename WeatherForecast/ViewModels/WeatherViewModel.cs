using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherForecast.Models;

namespace WeatherForecast.ViewModels;

public class WeatherViewModel : INotifyPropertyChanged {
    private WeatherData? _currentWeather;
    private readonly ObservableCollection<WeatherData> _forecast = [];
    public event PropertyChangedEventHandler? PropertyChanged;

    public WeatherViewModel() {
        Forecast = [];
    }

    public ObservableCollection<WeatherData> Forecast {
        get => _forecast;
        private init {
            _forecast = value;
            OnPropertyChanged();
        }
    }

    public WeatherData? CurrentWeather {
        get => _currentWeather;
        set {
            _currentWeather = value;
            OnPropertyChanged();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
