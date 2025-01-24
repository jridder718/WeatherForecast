using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherForecast.Models;
using WeatherForecast.Services.Api;
using WeatherForecast.Services.Factory;

namespace WeatherForecast.ViewModels;

public class WeatherViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;
    private WeatherData? _currentWeather;
    private ObservableCollection<WeatherData> _forecast = [];
    private readonly IWeatherApiService _apiService;

    public WeatherViewModel(IWeatherApiService? apiService = null) {
        _apiService = apiService ?? new WeatherApiService();
        Forecast = [];
        LoadWeatherData();
    }

    public ObservableCollection<WeatherData> Forecast {
        get => _forecast;
        private set {
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

    private void LoadWeatherData(double latitude = 51.5074, double longitude = -0.1276) {
        try {
            var weatherData = _apiService.GetWeatherData(longitude, latitude);
            var weatherViewModelData = WeatherViewModelDataFactory.Create(weatherData);
            CurrentWeather = weatherViewModelData.CurrentWeather;
            Forecast = weatherViewModelData.Forecast;
        }
        catch (Exception ex) {
            // ignored
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
