using System.Collections.ObjectModel;

namespace WeatherForecast.Models;

public class WeatherViewModelData {
    public required WeatherData CurrentWeather { get; init; }
    public required ObservableCollection<WeatherData> Forecast { get; init; }
}
